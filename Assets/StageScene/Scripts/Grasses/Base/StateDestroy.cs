using UnityEngine;
using System.Collections;

namespace MowingPlanetCompany.StageScene
{
    /// <summary>
    /// StateDestroy
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public  class StateDestroy<T> : State<T, GrassState> where T : GrassesBase<T>
    {
        public StateDestroy(T owner, GrassState identity) : base(owner, identity) { }

        public override void Enter()
        {
            base.Enter();
            Debug.Log($"{owner.gameObject.name}. {owner.StateMachine.CurrentState}");
            // 上方ベクトルとランダムなベクトル方向に飛ばす
            var force = Vector3.up * owner.HeightPower + Random.insideUnitSphere * owner.SpherePower;
            owner.GetComponent<Rigidbody>().AddForce(force);

            // 指定秒数遅延後オブジェクト破壊
            GameObject.Destroy(owner.gameObject, owner.DestoryDelayTime);
        }
        public override void Execute() { }
        public override void Exit() { }
    }
}