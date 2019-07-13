using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MowingPlanetCompany.StageScene
{
    public class InTheGame : StateBehaviourBase
    {
        private void Start()
        {
            // Register event
            worldStateMachine.m_BehaviourByState.AddListener((state) =>
            {
                if (state != WorldStateMachine.States.State.InTheGame)
                {
                    return;
                }
                Debug.Log("Called InTheGame.");
            });
        }
    }
}