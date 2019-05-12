﻿using UnityEngine;
using System.Collections;

namespace MowingPlanetCompany.StageScene
{
    public class StateMachine<T>
    {
        State<T> currentState;

        public StateMachine()
        {
            currentState = null;
        }

        public State<T> CurrentState
        {
            get
            {
                return currentState;
            }
        }

        public void ChangeState(State<T> state)
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
                currentState.Excute();
            }
        }
    }
}
