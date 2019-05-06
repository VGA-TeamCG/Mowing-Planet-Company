using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MowingPlanetCompany.StageScene
{
    abstract public class GrassesBase : MonoBehaviour, IMovable
    {
        #region Properties
        /// <summary>ノーマル草の一体毎のポイント</summary>
        public int GrassPerPoint { get { return grassPerPoint; } set { grassPerPoint = value; } }
        /// <summary>ノーマル草のスコア</summary>
        public int GrassScore { get { return grassScore; } set { grassScore = value; } }
        /// <summary>この草の識別子</summary>
        public GrassID GrassId { get { return grassID; } set { grassID = value; } }
        #endregion

        #region Variables
        [Header("ノーマル草の一体毎のポイント")]
        [SerializeField] protected int grassPerPoint;
        [Header("ノーマル草のスコア")]
        [SerializeField] protected int grassScore;
        [Header("この草の識別子")]
        [SerializeField] protected GrassID grassID;
        #endregion

        #region Methods
        /// <summary>
        /// Colliderと衝突した時のコールバック
        /// </summary>
        /// <param name="other"></param>
        private void OnTriggerEnter(Collider other)
        {
            Debug.Log(other.gameObject.name);
            if (other.gameObject.tag == "Weapon")
            {
                OnCollideWeapon();
            }
        }

        /// <summary>
        /// Mowieの武器と接触した時
        /// </summary>
        public abstract void OnCollideWeapon();
        /// <summary>
        /// 動く時
        /// </summary>
        public abstract void Move();
        /// <summary>
        /// 待機する時
        /// </summary>
        public abstract void Idle();
        #endregion
    }
}
