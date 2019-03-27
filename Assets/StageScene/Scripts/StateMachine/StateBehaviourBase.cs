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
        protected StageManager m_stageManager;
        /// <summary></summary>
        protected PlayerController m_playerController;

        protected virtual void Awake()
        {
            m_stageManager = StageManager.Instance;
            m_playerController = PlayerController.Instance;
        }
    }
}
