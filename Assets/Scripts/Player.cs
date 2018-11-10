using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MowingPlanet.BattleScene
{

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
            var horizontal = Input.GetAxis("Horizontal");
            var vertical = Input.GetAxis("Vertical");

            if(horizontal != 0f || vertical != 0f)
            {
                var inputVec = new Vector3(horizontal, 0f, vertical); //インプットの合成値をベクトルに変換
                var targetRot = Quaternion.LookRotation(inputVec,Vector3.up); //入力された方向への回転
                var turnStep = angularVelocity * Time.deltaTime; // 個々のパフォーマンスに応じて数値を正規化
                if (transform.rotation != targetRot)
                {
                    transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, turnStep);
                }
                rb.velocity = inputVec * moveSpeed;

                animator.SetFloat(parametersSpeed, 1f);
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
                animator.SetTrigger(parametersAttack); //アニメーションアタック
                
            }
        }

        private void FixedUpdate()
        {
            Move();
            Attack();
        }
    }
}
