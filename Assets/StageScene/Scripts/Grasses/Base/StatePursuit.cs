﻿using UnityEngine;
using System.Collections;

namespace MowingPlanetCompany.StageScene
{
    /// <summary>
    /// StatePursuit
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class StatePursuit<T> : State<T, GrassState> where T : GrassesBase<T>
    {
        public StatePursuit(T owner, GrassState identity) : base(owner, identity) { }

        public override void Enter()
        {
            base.Enter();
            owner.GizmoObj.SetGizmo(owner.Status.PursuitRange);
            Debug.Log($"{owner.gameObject.name}. {owner.StateMachine.CurrentState}");
        }
        public override void Execute()
        {
            var distanceToPlayer = Vector3.Magnitude(owner.Player.position - owner.transform.position);
            if (distanceToPlayer > owner.Status.PursuitRange )
            {
                owner.ChangeState(GrassState.Wander);
            }

            // look at target position
            var targetRotation = Quaternion.LookRotation(owner.Player.position - owner.transform.position);
            owner.transform.rotation = Quaternion.Slerp(owner.transform.rotation, targetRotation, Time.deltaTime * owner.Status.RotationSmooth);

            // go to straight
            owner.transform.Translate(Vector3.forward * owner.Status.Speed * Time.deltaTime);
        }
        public override void Exit() { }
    }
    /// <summary>
    /// StatePause
    /// </summary>
    /// <typeparam name="T"></typeparam>
}