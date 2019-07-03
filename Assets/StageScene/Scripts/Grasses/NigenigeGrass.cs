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
            stateList.Add(new MyStateWander(this, GrassState.Wander));
            stateList.Add(new MyStateEscape(this, GrassState.Escape));
            stateList.Add(new MyStateAttack(this, GrassState.Attack));
            stateList.Add(new MyStateDestory(this, GrassState.ToDie));
            stateList.Add(new MyStatePursuit(this, GrassState.Pursuit));
            ChangeState(GrassState.Pursuit);
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
            public MyStateWander(NigenigeGrass owner, GrassState identity) : base(owner, identity) { }

            public override void Enter() { base.Enter(); }
            public override void Execute() { base.Execute(); }
            public override void Exit() { base.Exit(); }
        }

        /// <summary>
        /// 逃走ステート
        /// </summary>
        private class MyStateEscape : StateEscape<NigenigeGrass>
        {
            public MyStateEscape(NigenigeGrass owner, GrassState identity) : base(owner, identity) { }

            public override void Enter() { base.Enter(); }
            public override void Execute() { base.Execute(); }
            public override void Exit() { base.Exit(); }
        }

        /// <summary>
        /// 攻撃ステート
        /// </summary>
        private class MyStateAttack : StateAttack<NigenigeGrass>
        {
            public MyStateAttack(NigenigeGrass owner, GrassState identity) : base(owner, identity) { }

            public override void Enter() { base.Enter(); }
            public override void Execute() { base.Execute(); }
            public override void Exit() { base.Exit(); }
        }

        /// <summary>
        /// 破壊ステート
        /// </summary>
        private class MyStateDestory : StateDestroy<NigenigeGrass>
        {
            public MyStateDestory(NigenigeGrass owner, GrassState identity) : base(owner, identity) { }

            public override void Enter() { base.Enter(); }
            public override void Execute() { base.Execute(); }
            public override void Exit() { base.Exit(); }
        }

        /// <summary>
        /// 追跡ステート　
        /// </summary>
        private class MyStatePursuit : StatePursuit<NigenigeGrass>
        {
            public MyStatePursuit(NigenigeGrass owner, GrassState identity) : base(owner, identity) { }

            public override void Enter() { base.Enter(); }
            public override void Execute() { base.Execute(); }
            public override void Exit() { base.Exit(); }
        }
    }
}
