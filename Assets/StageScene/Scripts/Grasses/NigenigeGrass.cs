using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MowingPlanetCompany.StageScene
{
    /// <summary>
    /// ニゲニゲ草
    /// </summary>
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Collider))]
    public class NigenigeGrass : GrassesBase<NigenigeGrass>
    {

        private void Start()
        {
            Initialize();
        }

        public override void Initialize()
        {
            base.Initialize();
            stateList.Add(new MyStateWander(this));
            stateList.Add(new MyStateEscape(this));
            stateList.Add(new MyStateAttack(this));
            stateList.Add(new MyStateDestory(this));
            ChangeState(GrassState.Attack);
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

            public override void Enter() { base.Enter(); }
            public override void Excute() { base.Excute(); }
            public override void Exit() { base.Exit(); }
        }

        /// <summary>
        /// 逃走ステート
        /// </summary>
        private class MyStateEscape : StateEscape<NigenigeGrass>
        {
            public MyStateEscape(NigenigeGrass owner) : base(owner) { }

            public override void Enter() { base.Enter(); }
            public override void Excute() { base.Excute(); }
            public override void Exit() { base.Exit(); }
        }

        /// <summary>
        /// 攻撃ステート
        /// </summary>
        private class MyStateAttack : StateAttack<NigenigeGrass>
        {
            public MyStateAttack(NigenigeGrass owner) : base(owner) { }

            public override void Enter() { base.Enter(); }
            public override void Excute() { base.Excute(); }
            public override void Exit() { base.Exit(); }
        }

        /// <summary>
        /// 破壊ステート
        /// </summary>
        private class MyStateDestory : StateDestroy<NigenigeGrass>
        {
            public MyStateDestory(NigenigeGrass owner) : base(owner) { }

            public override void Enter() { base.Enter(); }
            public override void Excute() { base.Excute(); }
            public override void Exit() { base.Exit(); }
        }

        /// <summary>
        /// 追跡ステート　
        /// </summary>
        private class MyStatePursuit : StatePursuit<NigenigeGrass>
        {
            public MyStatePursuit(NigenigeGrass owner) : base(owner) { }

            public override void Enter() { base.Enter(); }
            public override void Excute() { base.Excute(); }
            public override void Exit() { base.Exit(); }
        }
    }
}
