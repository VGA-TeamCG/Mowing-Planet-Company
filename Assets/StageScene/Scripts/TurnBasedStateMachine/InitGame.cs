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
        protected override void Awake()
        {
            base.Awake();
            // Register event
            wsm.m_BehaviourByState.AddListener((state) =>
            {
                if(!wsm.WheterCurrentState(state))
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