using UnityEngine;
using System.Collections;

namespace MowingPlanetCompany.StageScene
{
/// <summary>
/// StateAttack
/// </summary>
/// <typeparam name="T"></typeparam>
public class StateAttack<T> : State<T, GrassState> where T : GrassesBase<T>
{
    public StateAttack(T owner, GrassState identity) : base(owner, identity) { }

    public override void Enter()
    {
        base.Enter();
        Debug.Log($"{owner.gameObject.name}. {owner.StateMachine.CurrentState}");
    }
    public override void Execute()
    {
        // Playerとの距離が大きければ追跡ステートに遷移
        var distanceToPlayer = Vector3.Magnitude(owner.transform.position - owner.Player.position);
        owner.GizmoObj.SetGizmo(owner.Status.AttackDistance);
        if (distanceToPlayer > owner.Status.AttackDistance)
        {
            owner.ChangeState(GrassState.Pursuit);
        }
        Debug.Log("Attackしたよ");
    }
    public override void Exit() { }
}
}
