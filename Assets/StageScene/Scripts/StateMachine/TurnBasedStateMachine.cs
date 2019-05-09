using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace MowingPlanetCompany.StageScene
{
    /// <summary>
    /// StateMachine.
    /// </summary>
    public class TurnBasedStateMachine : MonoSingleton<TurnBasedStateMachine>
    {
        /// <summary>State machine</summary>
        public States m_StateMachine;
        /// <summary>Custom UnityEvent</summary>
        public StateMachineEvent m_BehaviourByState = new StateMachineEvent();

        /// <summary>
        /// 指定したステートに遷移させてEventを発行する
        /// </summary>
        /// <param name="state">State machine.</param>
        public void SetStateMachine(States.State state)
        {
            // ステート遷移前のステートを保存 
            m_StateMachine.PreviousState = m_StateMachine.NowState;
            if (state == States.State.Pause ) // 遷移先がPauseステートの時保存
            {
                m_StateMachine.StateBeforeWithoutSpecialState = m_StateMachine.NowState;
            }
            m_StateMachine.NowState = state; // stateをセット

            Debug.Log(state);
            // ==================================
            // イベント呼び出し
            // ==================================
            m_BehaviourByState.Invoke(state);
        }

        /// <summary>
        /// State machine event.
        /// </summary>
        public class StateMachineEvent : UnityEvent<States.State>
        { 
            public StateMachineEvent() { }
        }

        /// <summary>
        /// State machine.
        /// </summary>
        public class States
        {
            /// <summary>Represents the current state.</summary>
            public State NowState { get; set; }
            public State PreviousState { get; set; }
            public State StateBeforeWithoutSpecialState { get; set; } 

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

