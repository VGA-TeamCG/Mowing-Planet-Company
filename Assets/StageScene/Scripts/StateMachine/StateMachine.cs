using UnityEngine;
using System.Collections;

namespace MowingPlanetCompany.StageScene
{
    public class StateMachine<T, TEnum>
    {
        State<T, TEnum> currentState;

        public StateMachine()
        {
            currentState = null;
        }

        public State<T, TEnum> CurrentState
        {
            get
            {
                return currentState;
            }
        }

        public void ChangeState(State<T, TEnum> state)
        {
            if (currentState != null)
            {
                currentState.Exit();
            }
            currentState = state;
            currentState.Enter();
        }

        public void Update()
        {
            if (currentState != null)
            {
                currentState.Execute();
            }
        }
    }
}
