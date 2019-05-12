using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MowingPlanetCompany.StageScene
{
    public class NigenigeGrass : GrassesBase<NigenigeGrass>
    {

        private void Start()
        {
            Initialize();
        }

        public override void Initialize()
        {
            base.Initialize();
            stateList.Add(new MyStateEscape(this));
            stateList.Add(new MyStateWander(this));
            stateList.Add(new MyStateAttack(this));
            stateList.Add(new MyStateDestory(this));
            ChangeState(GrassState.Wander);
        }

        protected override void Update()
        {
            base.Update();
        }

        /// <summary>
        /// 徘徊ステート
        /// </summary>
        private class MyStateWander : StateWander<NigenigeGrass>
        {
            Vector3 targetPosition;
            public MyStateWander(NigenigeGrass owner) : base(owner) { }

            public override void Enter()
            {
                targetPosition = GetRandomPositionOnLevel();
            }
            public override void Excute()
            {
                // プレイヤーとの距離が小さければ追跡ステートに遷移
                var sqrDistanceToPlayer = Vector3.SqrMagnitude(owner.transform.position - owner.player.position);
                if (sqrDistanceToPlayer < owner.status.PursuitSqrDistance - owner.status.Margin)
                {
                    //  change state.
                    owner.ChangeState(GrassState.Pursuit);
                }

                // 目標地点との距離が小さければ、次のランダムな目標地点を設定する
                var sqrDistanceToTarget = Vector3.SqrMagnitude(owner.transform.position - targetPosition);
                if (sqrDistanceToTarget < owner.status.ChangeTargetSqrDistance)
                {
                    targetPosition = GetRandomPositionOnLevel();
                }

                // look at target position
                var targetRotation = Quaternion.LookRotation(targetPosition - owner.transform.position);
                owner.transform.rotation = Quaternion.Slerp(owner.transform.rotation, targetRotation, Time.deltaTime * owner.status.RotationSmooth);

                // go to straight
                owner.transform.Translate(Vector3.forward * owner.status.Speed * Time.deltaTime);
            }
            public override void Exit() { }

            /// <summary>
            /// 指定半径内の座標をランダムに返す
            /// </summary>
            /// <returns></returns>
            public Vector3 GetRandomPositionOnLevel()
            {
                var radius = owner.status.ActivityRange;
                return new Vector3(Random.Range(-radius, radius), 0f, Random.Range(-radius, radius));
            }
        }

        /// <summary>
        /// 逃走ステート
        /// </summary>
        private class MyStateEscape : StateEscape<NigenigeGrass>
        {
            public MyStateEscape(NigenigeGrass owner) : base(owner) { }

            public override void Enter()
            {
                Debug.Log("Now it's Escape state.");
            }
            public override void Excute()
            {
                var sqrDistanceToPlayer = Vector3.SqrMagnitude(owner.player.position - owner.transform.position);
                if (sqrDistanceToPlayer > owner.status.EscapeSqrDistance - owner.status.Margin)
                {
                    owner.ChangeState(GrassState.Wander);
                }

                // look at target position
                var targetRotation = Quaternion.LookRotation(owner.player.position - owner.transform.position);
                owner.transform.rotation = Quaternion.Slerp(owner.transform.rotation, targetRotation, Time.deltaTime * owner.status.RotationSmooth);

                // go to straight
                owner.transform.Translate(Vector3.forward * owner.status.Speed * Time.deltaTime);
            }
            public override void Exit() { }
        }

        /// <summary>
        /// 攻撃ステート
        /// </summary>
        private class MyStateAttack : StateAttack<NigenigeGrass>
        {
            public MyStateAttack(NigenigeGrass owner) : base(owner) { }

            public override void Enter() { }
            public override void Excute()
            {
                // Playerとの距離が大きければ追跡ステートに遷移
                var sqrDistanceToPlayer = Vector3.SqrMagnitude(owner.transform.position - owner.player.position);
                if (sqrDistanceToPlayer > owner.status.AttackSqrDistance + owner.status.Margin)
                {
                    owner.ChangeState(GrassState.Pursuit);
                }
                Debug.Log("Attackしたよ");
            }
            public override void Exit() { }
        }

        /// <summary>
        /// 破壊ステート
        /// </summary>
        private class MyStateDestory : StateDestroy<NigenigeGrass>
        {
            public MyStateDestory(NigenigeGrass owner) : base(owner) { }

            public override void Enter()
            {
                // 上方ベクトルとランダムなベクトル方向に飛ばす
                var force = Vector3.up * owner.HeightPower + Random.insideUnitSphere * owner.SpherePower;
                owner.GetComponent<Rigidbody>().AddForce(force);

                // 指定秒数遅延後オブジェクト破壊
                Destroy(owner.gameObject, owner.DestoryDelayTime);
            }
            public override void Excute() { }
            public override void Exit() { }
        }

        /// <summary>
        /// 追跡ステート　
        /// </summary>
        private class MyStatePursuit : StatePursuit<NigenigeGrass>
        {
            public MyStatePursuit(NigenigeGrass owner) : base(owner) { }

            public override void Enter() { }
            public override void Excute()
            {
                var sqrDistanceToPlayer = Vector3.SqrMagnitude(owner.player.position - owner.transform.position);
                if (sqrDistanceToPlayer > owner.status.PursuitSqrDistance - owner.status.Margin)
                {
                    owner.ChangeState(GrassState.Wander);
                }

                // look at target position
                var targetRotation = Quaternion.LookRotation(owner.player.position - owner.transform.position);
                owner.transform.rotation = Quaternion.Slerp(owner.transform.rotation, targetRotation, Time.deltaTime * owner.status.RotationSmooth);

                // go to straight
                owner.transform.Translate(Vector3.forward * owner.status.Speed * Time.deltaTime);
            }
            public override void Exit() { }
        }
    }
}
