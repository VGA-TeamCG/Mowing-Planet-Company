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
        protected WorldStateMachine wsm;
        /// <summary></summary>
        protected PlayerController playerCtrl;

        protected virtual void Awake()
        {
            wsm = WorldStateMachine.Instance;
            playerCtrl = PlayerController.Instance;
        }
    }
}
