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
        [SerializeField] float firstWaitTime = 5f;
        private void Start()
        {
            // Register event
            worldStateMachine.m_BehaviourByState.AddListener((state) =>
            {
                if(state != WorldStateMachine.States.State.InitGame)
                {
                    return;
                }
                StartCoroutine(Initialize());
            });
        }
        IEnumerator Initialize()
        {
            yield return new WaitForSeconds(firstWaitTime);
            gameStarter.StartCountDown();
        }
    }
}