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
        WorldStateMachine worldStateMachine;
        #endregion
        #region Methods
        #endregion
        #region Callbacks
        private void Awake()
        {
            timeManager = TimeManager.Instance;
            worldStateMachine = WorldStateMachine.Instance;
        }
        private void Start()
        {
            worldStateMachine.SetStateMachine(WorldStateMachine.States.State.InitGame);
        }
        #endregion
        #region Enums
        #endregion
    }
}
