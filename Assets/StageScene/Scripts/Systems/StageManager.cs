using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MowingPlanetCompany.StageScene
{
    public class StageManager : MonoSingleton<StageManager>
    {

        #region Properties
        #endregion
        #region Variables
        TimeManager timeManager;
        #endregion
        #region Methods
        void StartGame()
        {
            timeManager.StartCountDown();
        }
        #endregion
        #region Callbacks
        private void Awake()
        {
            timeManager = TimeManager.Instance;
        }
        private void Start()
        {
            StartGame();
        }
        #endregion
        #region Enums
        #endregion
    }
}
