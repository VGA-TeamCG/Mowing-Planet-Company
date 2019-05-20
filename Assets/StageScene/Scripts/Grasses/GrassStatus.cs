using UnityEngine;
using System.Collections;

namespace MowingPlanetCompany.StageScene
{
    [System.Serializable]
    public class GrassStatus : Status
    {
        /// <summary>ノーマル草の一体毎のポイント</summary>
        public int GrassPerPoint { get { return grassPerPoint; } set { grassPerPoint = value; } }
        /// <summary>ノーマル草のスコア</summary>
        public int GrassScore { get { return grassScore; } set { grassScore = value; } }
        /// <summary>この草の識別子</summary>
        public GrassID GrassId { get { return grassID; } set { grassID = value; } }
        /// <summary>有効半径</summary>
        public float ActivityRange { get { return activityRange; } set { activityRange = value; } }
        /// <summary>追跡に遷移するかどうかを判断する距離(2乗)</summary>
        public float PursuitSqrDistance { get { return pursuitSqrDistance; } set { pursuitSqrDistance = value; } }
        /// <summary>攻撃ステート用範囲</summary>
        public float AttackSqrDistance { get { return attackSqrDistance; } set { attackSqrDistance = value; } }
        /// <summary>範囲マージン</summary>
        public float Margin { get { return margin; } set { margin = value; } }
        /// <summary>徘徊ステート時のターゲット変更距離</summary>
        public float ChangeTargetSqrDistance { get { return changeTargetSqrDistance; } set { changeTargetSqrDistance = value; } }
        /// <summary>キャラ回転の補間レート</summary>
        public float RotationSmooth { get { return rotationSmooth; } set { rotationSmooth = value; } }
        /// <summary>逃走ステート用範囲</summary>
        public float EscapeSqrDistance { get { return escapeSqrDistance; } set { escapeSqrDistance = value; } }


        [Header("ノーマル草の一体毎のポイント")]
        [SerializeField] protected int grassPerPoint;
        [Header("ノーマル草のスコア")]
        [SerializeField] protected int grassScore;
        [Header("この草の識別子")]
        [SerializeField] protected GrassID grassID;
        [Header("有用半径")]
        [SerializeField] float activityRange;
        [Header("追跡ステート用範囲")]
        [SerializeField] float pursuitSqrDistance;
        [Header("攻撃ステート用範囲")]
        [SerializeField] float attackSqrDistance;
        [Header("逃走ステート用範囲")]
        [SerializeField] float escapeSqrDistance;
        [Header("範囲マージン")]
        [SerializeField] float margin;
        [Header("徘徊ステート時のターゲット変更距離")]
        [SerializeField] float changeTargetSqrDistance;
        [Header("キャラ回転の補間レート")]
        [SerializeField] float rotationSmooth;
    }
}
