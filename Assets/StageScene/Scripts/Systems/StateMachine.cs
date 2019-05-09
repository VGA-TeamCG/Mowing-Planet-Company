using UnityEngine;
using System.Collections;

namespace MowingPlanetCompany.StageScene
{
    public class StateMachine<T>
    {
        private State<T> currentState;
        


        public void ChangeState(State<T> state)
        {
            if(currentState!= null)
            {
                currentState.Exit();
            }
            currentState = state;
            currentState.Enter();
        }

    }
}
