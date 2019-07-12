using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MowingPlanetCompany.StageScene
{
    /// <summary>
    /// Initialize Game
    /// </summary>
    public class InitGame : StateBehaviourBase
    {
        [SerializeField] GameStarter gameStarter;

        private void Start()
        {
            // Register event
            m_stageManager.m_BehaviourByState.AddListener((state) =>
            {
                if(state != TurnBasedStateMachine.States.State.InitGame)
                {
                    return;
                }

                gameStarter.
                
                
            });
        }
    }
}

