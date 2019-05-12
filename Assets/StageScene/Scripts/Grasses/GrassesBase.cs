using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MowingPlanetCompany.StageScene
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T">各草クラス.</typeparam>
    public class GrassesBase<T> : StatefulObjectBase<T, GrassState> where T : class
    {
        #region Properties
        public GrassStatus Status { get { return status; } set { status = value; } }
        public float HeightPower { get { return heightPower; } set { heightPower = value; } }
        public float SpherePower { get { return spherePower; } set { spherePower = value; } }
        public float DestoryDelayTime { get { return destroyDelayTime; } set { destroyDelayTime = value; } }
        #endregion

        #region Variables
        [SerializeField] protected GrassStatus status;
        /// <summary>上に飛ばす強さ</summary>
        [SerializeField] float heightPower;
        /// <summary>球体上のランダムな方角に飛ばす強さ</summary>
        [SerializeField] float spherePower;
        /// <summary>破壊迄の遅延時間</summary>
        [SerializeField] float destroyDelayTime = 1f;

        protected Transform player;
        #endregion

        #region Methods
        public virtual void Initialize()
        {
            player = GameObject.FindWithTag("Player").transform;
            status.Initialize();
        }

        /// <summary>
        /// Colliderと衝突した時のコールバック
        /// </summary>
        /// <param name="other"></param>
        protected virtual void OnTriggerEnter(Collider other)
        {
            Debug.Log(other.gameObject.name);
            if (other.gameObject.tag == "Weapon")
            {
                OnCollideWeapon();
            }
        }



        /// <summary>
        /// on collide weapon of player
        /// </summary>
        public virtual void OnCollideWeapon()
        {
            var damage = player.GetComponent<Mowie>().MyStatus.Atk;
            status.Life -= damage;
            if (status.Life <= 0)
            {
                ChangeState(GrassState.ToDie);
            }
        }
        #endregion

        #region EachStateBehaviour
        protected class StateWander<T> : State<T> where T : class
        {
            public StateWander(T owner) : base(owner) { }

            public override void Enter() { }
            public override void Excute() { }
            public override void Exit() { }
        }
        protected class StateAttack<T> : State<T> where T : class
        {
            public StateAttack(T owner) : base(owner) { }

            public override void Enter() { }
            public override void Excute() { }
            public override void Exit() { }
        }
        protected class StateEscape<T> : State<T> where T : class
        {
            public StateEscape(T owner) : base(owner) { }

            public override void Enter() { }
            public override void Excute() { }
            public override void Exit() { }
        }
        protected class StateDestroy<T> : State<T> where T : class
        {
            public StateDestroy(T owner) : base(owner) { }

            public override void Enter()
            {

            }
            public override void Excute() { }
            public override void Exit() { }
        }
        protected class StatePursuit<T> : State<T> where T : class
        {
            public StatePursuit(T owner) : base(owner) { }

            public override void Enter() { }
            public override void Excute() { }
            public override void Exit() { }
        }
        #endregion
    }
    public enum GrassState
    {
        Wander,
        Pursuit,
        Attack,
        Escape,
        ToDie,
    }

    public enum GrassID
    {
        Normal,
        Nigenige,
        Pakupaku,
        Tsukitsuki,
    }
}
