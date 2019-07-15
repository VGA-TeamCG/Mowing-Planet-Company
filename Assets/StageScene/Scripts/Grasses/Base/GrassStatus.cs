using UnityEngine;
using System.Collections;

namespace MowingPlanetCompany.StageScene
{
    [System.Serializable]
    public class GrassStatus : Status
    {
        /// <summary>ノーマル草の一体毎のポイント</summary>
        public int GrassPoint { get { return grassPoint; } set { grassPoint = value; } }
        /// <summary>この草の識別子</summary>
        public GrassID GrassId { get { return grassID; } set { grassID = value; } }
        /// <summary>有効半径</summary>
        public float ActiveRange { get { return activeRange; } set { activeRange = value; } }
        /// <summary>state遷移するかどうかを判断する距離</summary>
        public float PursuitRange { get { return pursuitRange; } set { pursuitRange = value; } }
        /// <summary>プレイヤーを検出する範囲</summary>
        public float DetectSensorRange { get { return detectSensorRange; } set { detectSensorRange = value; } }

        /// <summary>攻撃ステート用範囲</summary>
        public float AttackDistance { get { return attackDistance; } set { attackDistance = value; } }
        /// <summary>範囲マージン</summary>
        public float Margin { get { return margin; } set { margin = value; } }
        /// <summary>徘徊ステート時のターゲット変更距離</summary>
        public float ChangeTargetDistance { get { return changeTargetDistance; } set { changeTargetDistance = value; } }
        /// <summary>キャラ回転の補間レート</summary>
        public float RotationSmooth { get { return rotationSmooth; } set { rotationSmooth = value; } }
        /// <summary>逃走ステート用範囲</summary>
        public float EscapeDistance { get { return escapeDistance <= detectSensorRange ? detectSensorRange + margin : escapeDistance; } set { escapeDistance = value; } }
        public float ChangeStateLimitTime { get { return changeStateLimitTime; } set { changeStateLimitTime = value; } }


        [Header("ノーマル草の一体毎のポイント")]
        [SerializeField] protected int grassPoint;
        [Header("この草の識別子")]
        [SerializeField] protected GrassID grassID;
        [Header("ランダム座標の最大半径")]
        [SerializeField] float activeRange;
        [Header("追跡ステート用範囲")]
        [SerializeField] float pursuitRange;
        [Header("攻撃ステート用範囲")]
        [SerializeField] float attackDistance;
        [Header("逃走ステート用範囲")]
        [SerializeField] float escapeDistance;
        [Header("範囲マージン")]
        [SerializeField] float margin = 2;
        [Header("徘徊ステート時のターゲット変更距離")]
        [SerializeField] float changeTargetDistance;
        [Header("キャラ回転の補間レート")]
        [SerializeField] float rotationSmooth;
        [Header("ステートを変更させるリミットタイム")]
        [SerializeField] float changeStateLimitTime;
        [Header("プレイヤーを検知するセンサーの範囲")]
        [SerializeField] float detectSensorRange;
    }
}
