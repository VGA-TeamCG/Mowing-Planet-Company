using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MowingPlanet.BattleScene
{
    /// <summary>
    /// animator state machineのステート一覧
    /// </summary>
    public enum AnimState
    {
        RightAttack, LeftAttack, UpperAttack
    }
    
    /// <summary>
    /// プレイヤー
    /// </summary>
    public class Player : MovingObject
    {
        /// <summary>草に与えるダメージ量</summary>
        public int grassDamage = 1;
        /// <summary>草を倒す毎に貰えるポイント</summary>
        public int pointPerGrass = 10;
        /// <summary>を倒す毎に貰えるポイント</summary>
        public int pointPerManEatingGrass = 500;
        /// <summary>人面樹を倒す毎に貰えるポイント</summary>
        public int pointPerHumanFaceTree = 1000;
        /// <summary>プレイヤーの移動速度</summary>
        public float moveSpeed = 3f;
        /// <summary>プレイヤーが回転する速度</summary>
        public float angularVelocity = 8f;

        private CapsuleCollider capsuleCollider;
        private Animator animator;
        /// <summary>AnimatorControllerのパラメータ : Speed</summary>
        private string parametersSpeed = "Speed";
        /// <summary>AnimatorControllerのパラメータ : Attack</summary>
        private string parametersAttack = "Attack";
        /// <summary>AnimatorControllerのパラメータ : Speed</summary>
        private string parametersisRun = "isRunning";
        private AnimState animState;

        protected override void Start()
        {
            animator = GetComponent<Animator>();
            capsuleCollider = GetComponent<CapsuleCollider>();
            base.Start();
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void Move()
        {
            var input = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

            //方向キーが入力されている、且つ攻撃中ではない時
            if (input.magnitude > 0f
                && !animator.GetCurrentAnimatorStateInfo(0).IsName(AnimState.LeftAttack.ToString())
                && !animator.GetCurrentAnimatorStateInfo(0).IsName(AnimState.RightAttack.ToString())
                && !animator.GetCurrentAnimatorStateInfo(0).IsName(AnimState.UpperAttack.ToString())
                )
            {
                var targetRot = Quaternion.LookRotation(input,Vector3.up); //入力された方向への回転
                var turnStep = angularVelocity * Time.deltaTime; // 個々のパフォーマンスに応じて数値を正規化
                if (transform.rotation != targetRot) //回転先と自分の回転が一緒ではない時
                {
                    transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, turnStep);　//sleap(球体線形補間),回転させる
                }
                rb.velocity = input * moveSpeed; // 方向キーの指す先 * 任意のスピードで移動させる
                animator.SetFloat(parametersSpeed, 1f); //走るモーションをさせる
            }
            else
            {
                animator.SetFloat(parametersSpeed, 0f);
            }
        }

        private void Attack()
        {
            if (Input.GetMouseButtonDown(0))
            {
                animator.SetTrigger(parametersAttack); //アタックアニメーション
            }
        }

        private void FixedUpdate()
        {
            Move();
            Attack();
        }

        private void DisabledRunning()
        {
            
        }
    }
}
