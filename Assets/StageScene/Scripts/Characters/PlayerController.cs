using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MowingPlanetCompany.StageScene
{

    public class PlayerController : MonoSingleton<PlayerController>, ICommandHandler
    {
        #region Field
        [Header("Parameters")]

        /// <summary>移動速度を調整するパラメータ</summary>
        [SerializeField] protected float m_moveSpeed = 5f;
        /// <summary>プレイヤーが回転する速度</summary>
        [SerializeField] float m_turnSpeed = 8f;
        /// <summary>ジャンプ力を調整するパラメータ</summary>
        [SerializeField] float m_jumpPower = 10f;
        // 重力加速度を調整するパラメーター
        [SerializeField] float m_gravityMultiplier = 1f;




        [Header("Components")]

        /// <summary>同じオブジェクトに追加された CharacterController への参照</summary>
        protected CharacterController m_charaCtrl;
        /// <summary>操作の標準とする向き</summary>
        [SerializeField] Transform m_directionalStandard;
        /// <summary>浮動ジョイスティック</summary>
        [SerializeField] FloatingJoystick m_FJoyStick;
        TimeManager m_timeManager;


        /// <summary>同じオブジェクトに追加された Animator への参照</summary>
        private Animator m_anim;
        /// <summary>Animator Controller のステート名</summary>
        private AnimState m_animState;
        /// <summary>Animator Controller のパラメーター名</summary>
        private AnimParameter m_animParameter;
        // 縦方向の速度
        private float m_verticalVelocity = 0f;

        #endregion
        #region Method
        private void Awake()
        {
            m_anim = GetComponent<Animator>();
            m_charaCtrl = GetComponent<CharacterController>();
            m_timeManager = TimeManager.Instance;
        }

        private void Move()
        {
            //方向の入力を取得する
            float h = (Input.GetAxis("Horizontal") == 0f) ? m_FJoyStick.Horizontal : Input.GetAxis("Horizontal"); //方向キーの入力が無い時はジョイスティックから入力をとる
            float v = (Input.GetAxis("Vertical") == 0f) ? m_FJoyStick.Vertical : Input.GetAxis("Vertical"); // 方向キーの入力が無い時はジョイスティックから入力をとる
            Vector3 dir = Vector3.zero; //directionの略。移動する方向を表す。ここでは移動する方向の速度ベクトルを表す。

            // x-z 平面(地面と平行)の速度を求める
            dir += new Vector3(h, 0, v) * m_moveSpeed; // 方向の入力で、x-z平面の移動方向が決まる。

            if (dir != Vector3.zero //移動の入力がされている、且つ攻撃モーションではない時
                && !m_anim.GetCurrentAnimatorStateInfo(0).IsName(AnimState.SecondCombo.ToString())
                && !m_anim.GetCurrentAnimatorStateInfo(0).IsName(AnimState.FirstCombo.ToString())
                && !m_anim.GetCurrentAnimatorStateInfo(0).IsName(AnimState.ThirdCombo.ToString())
                )
            {
                dir = m_directionalStandard.TransformDirection(dir);//カメラに対して正面の向きに変換する
                dir.y = 0; // キャラを常に水平方向に向ける
                transform.forward = Vector3.Slerp(transform.forward, dir, m_turnSpeed); // 入力された向きに対して少し遅延しながら入力方向に向かせる
                m_charaCtrl.Move(dir * Time.deltaTime); // ここでキャラクターを入力方向へ動かす
                m_anim.SetFloat(AnimParameter.Speed.ToString(), dir.sqrMagnitude);
            }
            else // 移動していない時
            {
                m_anim.SetFloat(AnimParameter.Speed.ToString(), 0f); //Idleへ遷移させる
            }

            // y軸(垂直方向)の速度を求める
            if (m_charaCtrl.isGrounded) // 地面に接地していなければ
            {
                //アニメーションを制御する
                m_anim.SetBool(AnimParameter.IsGrounded.ToString(), true);
                m_anim.SetFloat(AnimParameter.Speed.ToString(), dir.sqrMagnitude); // 着地している時且つ動いている時はRunに遷移する。動いていなければIdleにとどまる。

                m_verticalVelocity = 0; // 接地していれば垂直方向の速度は0になる
            }
            else
            {
                // 接地していない時(空中にいる時)は重力に従って垂直方向の速度は減速し、マイナスになる
                m_verticalVelocity -= Physics.gravity.magnitude * m_gravityMultiplier * Time.deltaTime;
            }
        }

        /// <summary>
        /// Update
        /// </summary>
        private void Update()
        {
            Move();
        }

        /// <summary>
        /// Ons the attack.
        /// </summary>
        public void OnAttack()
        {
            // 3連撃目ではない時Triggerをセットする　
            if (!m_anim.GetCurrentAnimatorStateInfo(0).IsName(AnimState.ThirdCombo.ToString()))
            {
                m_anim.SetTrigger(AnimParameter.Attack.ToString()); //アタックアニメーション
            }
        }




        #endregion
        public enum AnimationStates
        {
            FirstCombo,
            SecondCombo,
            ThirdCombo,
            Idle,
            Run,
        }
    }
}
