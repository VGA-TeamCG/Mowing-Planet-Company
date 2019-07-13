using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MowingPlanetCompany.StageScene
{
    /// <summary>
    /// 
    /// </summary>
    public class StateBehaviourBase : MonoBehaviour
    {
        /// <summary></summary>
        protected WorldStateMachine worldStateMachine;
        /// <summary></summary>
        protected PlayerController playerCtrl;

        protected virtual void Awake()
        {
            worldStateMachine = WorldStateMachine.Instance;
            playerCtrl = PlayerController.Instance;
        }
    }
}
