using UnityEngine;
using System.Collections;

namespace MowingPlanetCompany.StageScene
{
    /// <summary>
    /// StateWander
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class StateWander<T> : State<T, GrassState> where T : GrassesBase<T>
    {
        public StateWander(T owner, GrassState identity) : base(owner, identity) { }
        Vector3 targetPosition;
        float changeDirectionTime = 5;
        float time;
        GameObject posGizmo;


        public override void Enter()
        {
            base.Enter();
            Debug.Log($"{owner.gameObject.name}. {owner.StateMachine.CurrentState}");
            targetPosition = GetRandomPositionOnLevel();
            posGizmo = GameObject.Instantiate(owner.PositionGizmo, targetPosition, Quaternion.identity);
            owner.GizmoObj.SetGizmo(owner.Status.DetectSensorRange);
            time = 0;
        }
        public override void Execute()
        {
            Debug.DrawLine(owner.transform.position, owner.transform.position + owner.transform.forward * 10, Color.red);
            time = Time.deltaTime;
            // ステートが始まってからが指定時間経ったらステート変更
            if (ElapsedTimeSinseStateStart > owner.Status.ChangeStateLimitTime)
            {
                owner.ChangeState(GrassState.Stop);
            }
            // プレイヤーとの距離が小さければEscapeステートに遷移
            var distanceToPlayer = Vector3.Magnitude(owner.transform.position - owner.Player.position);
            if (distanceToPlayer < owner.Status.DetectSensorRange)
            {
                //  change state.
                owner.ChangeState(GrassState.Escape);
            }
            // 目標地点との距離が小さければ、次のランダムな目標地点を設定する
            var distanceToTarget = Vector3.Magnitude(targetPosition - owner.transform.position);
            if (distanceToTarget < owner.Status.ChangeTargetDistance || time > changeDirectionTime)
            {
                targetPosition = GetRandomPositionOnLevel();
                if (posGizmo != null)
                {
                    GameObject.Destroy(posGizmo);
                    posGizmo = null;
                }
                posGizmo = GameObject.Instantiate(owner.PositionGizmo, targetPosition, Quaternion.identity);
                time = 0;
            }

            var vec = targetPosition - owner.transform.position;
            var targetRot = Quaternion.LookRotation(vec);
            owner.transform.rotation = Quaternion.Slerp(owner.transform.rotation, targetRot, owner.Status.RotationSmooth);
            owner.Rb.velocity = owner.gameObject.transform.forward * owner.Status.Speed;

        }
        public override void Exit()
        {
            if (posGizmo != null)
            {
                GameObject.Destroy(posGizmo);
                posGizmo = null;
            }
        }

        /// <summary>
        /// 指定半径内の座標をランダムに返す
        /// </summary>
        /// <returns></returns>
        public Vector3 GetRandomPositionOnLevel()
        {
            var radius = owner.Status.ActiveRange;
            var vec = new Vector3(Random.Range(-radius, radius), 0f, Random.Range(-radius, radius));
            return vec;
        }
    }
}