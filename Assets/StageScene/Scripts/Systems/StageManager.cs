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
        TurnBasedStateMachine TBStateMachine;
        #endregion
        #region Methods
        #endregion
        #region Callbacks
        private void Awake()
        {
            timeManager = TimeManager.Instance;
            TBStateMachine = TurnBasedStateMachine.Instance;
        }
        private void Start()
        {
            TBStateMachine.SetStateMachine(TurnBasedStateMachine.States.State.InitGame);
        }
        #endregion
        #region Enums
        #endregion
    }
}
