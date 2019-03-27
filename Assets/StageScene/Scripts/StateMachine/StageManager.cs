using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace MowingPlanetCompany.StageScene
{
    /// <summary>
    /// Stage manager.
    /// </summary>
    public class StageManager : MonoSingleton<StageManager>
    {
        /// <summary>State machine</summary>
        public StateMachine m_StateMachine;
        /// <summary>Custom UnityEvent</summary>
        public StateMachineEvent m_BehaviourByState = new StateMachineEvent();





        /// <summary>
        /// State machine event.
        /// </summary>
        public class StateMachineEvent : UnityEvent<StateMachine.State>
        { 
            public StateMachineEvent() { }
        }

        /// <summary>
        /// State machine.
        /// </summary>
        public class StateMachine
        {
            /// <summary>Represents the current state.</summary>
            public State m_state = State.InitGame;

            /// <summary>
            /// States.
            /// </summary>
            public enum State
            {
                InitGame,
                InTheGame,
                GameOver,
                GameClear,
                Pause,
            }
        }
    }
}

