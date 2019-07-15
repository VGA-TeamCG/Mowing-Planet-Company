using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MowingPlanetCompany.StageScene
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T">各草クラス.</typeparam>
    [RequireComponent(typeof(GizmoObject), typeof(Rigidbody))]
    public abstract class GrassesBase<T> : StatefulObjectBase<T, GrassState> where T : class
    {
        #region Properties
        public GrassStatus Status { get { return status; } set { status = value; } }
        public float HeightPower { get { return heightPower; } set { heightPower = value; } }
        public float SpherePower { get { return spherePower; } set { spherePower = value; } }
        public float DestoryDelayTime { get { return destroyDelayTime; } set { destroyDelayTime = value; } }
        public GizmoObject GizmoObj => gizmoObj;
        public Transform Player { get; set; }
        public Rigidbody Rb { get; set; }

        public GameObject PositionGizmo => positionGizmo;
        #endregion

        #region Variables
        [SerializeField] GrassState currentState;
        [SerializeField] protected GrassStatus status;
        /// <summary>上に飛ばす強さ</summary>
        [SerializeField] float heightPower;
        /// <summary>球体上のランダムな方角に飛ばす強さ</summary>
        [SerializeField] float spherePower;
        /// <summary>破壊迄の遅延時間</summary>
        [SerializeField] float destroyDelayTime = 1f;
        [SerializeField] GameObject positionGizmo;
        protected TimeManager timeManager;
        /// <summary>Gizmo of sensor range</summary>
        protected GizmoObject gizmoObj;
        /// <summary>
        /// Gizumoのwidthに毎フレーム渡す値.
        /// ステート毎にここに代入する変数をかえる.
        /// </summary>
        protected float gizmoRange;
        #endregion

        #region Methods
        protected virtual void Awake()
        {
            timeManager = TimeManager.Instance;
            gizmoObj = GetComponent<GizmoObject>();
            Rb = GetComponent<Rigidbody>();
        }
        protected override void Update()
        {
            base.Update();
            //// ===============================================
            //// 転倒防止。　動くかは要確認
            //// ===============================================
            //var adjustRot = new Quaternion(0f, transform.rotation.y, 0f, transform.rotation.w);
            //transform.rotation = adjustRot;
            currentState = stateMachine.CurrentState.Identity;
            Debug.Log(stateMachine.CurrentState.Identity);
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
        public virtual void Initialize()
        {
            Player = GameObject.FindWithTag("Player").transform;
            status.Initialize();
        }
        /// <summary>
        /// on collide weapon of player
        /// </summary>
        public virtual void OnCollideWeapon()
        {
            var damage = Player.GetComponent<Mowie>().MyStatus.Atk;
            status.Life -= damage;
            if (status.Life <= 0)
            {
                ChangeState(GrassState.ToDie);
            }
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
        Stop,
    }

    public enum GrassID
    {
        Normal,
        Nigenige,
        Pakupaku,
        Tsukitsuki,
    }
}
