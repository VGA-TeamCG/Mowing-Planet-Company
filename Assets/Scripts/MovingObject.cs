using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MowingPlanet.BattleScene
{
    [RequireComponent(typeof(Rigidbody))]
    public abstract class MovingObject : MonoBehaviour
    {
        protected Rigidbody rb;

        protected virtual void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        protected abstract void Move();
    }
}
