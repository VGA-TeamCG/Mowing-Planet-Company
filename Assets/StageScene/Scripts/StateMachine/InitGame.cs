using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MowingPlanetCompany.StageScene
{
    /// <summary>
    /// 
    /// </summary>
    public class InitGame : StateBehaviourBase
    {
        private void Start()
        {
            // Register event
            m_stageManager.m_BehaviourByState.AddListener((state) =>
            {
                if(state != TurnBasedStateMachine.States.State.InitGame)
                {
                    return;
                }

                
            });
        }
    }
}

