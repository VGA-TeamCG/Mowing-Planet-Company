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
            wsm.m_BehaviourByState.AddListener((state) =>
            {
                if (!wsm.WheterCurrentState(state))
                {
                    return;
                }
                Debug.Log("Called InTheGame.");
            });
        }
    }
}