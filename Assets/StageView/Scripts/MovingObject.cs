using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MowingPlanet.StageScene
{
    public abstract class MovingObject : MonoBehaviour
    {
        /// <summary>同じオブジェクトに追加された CharacterController への参照</summary>
        protected CharacterController m_charaCtrl;

        protected virtual void Start()
        {
            m_charaCtrl = GetComponent<CharacterController>();
        }

        protected abstract void Move();
    }
}
