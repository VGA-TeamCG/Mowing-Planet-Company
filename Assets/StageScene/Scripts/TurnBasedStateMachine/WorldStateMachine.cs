using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace MowingPlanetCompany.StageScene
{
    /// <summary>
    /// StateMachine.
    /// </summary>
    public class WorldStateMachine : MonoSingleton<WorldStateMachine>
    {
        /// <summary>State machine</summary>
        public States m_StateMachine = new States();
        /// <summary>Custom UnityEvent</summary>
        public StateMachineEvent m_BehaviourByState = new StateMachineEvent();

        /// <summary>
        /// 現在のステートが指定した引数と同じステートかどうか
        /// </summary>
        /// <param name="state"></param>
        /// <returns>true = 同じステート. false = 同じステートではない</returns>
        public bool WheterCurrentState(States.State state) => m_StateMachine.CurrentState == state;
        /// <summary>
        /// 指定したステートに遷移させてEventを発行する
        /// </summary>
        /// <param name="state">State machine.</param>
        public void SetStateMachine(States.State state)
        {
            // ステート遷移前のステートを保存 
            m_StateMachine.PreviousState = m_StateMachine.CurrentState;
            if (state == States.State.Pause ) // 遷移先がPauseステートの時保存
            {
                m_StateMachine.StateBeforeWithoutSpecialState = m_StateMachine.CurrentState;
            }
            m_StateMachine.CurrentState = state; // stateをセット

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
            public State CurrentState { get; set; }
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

