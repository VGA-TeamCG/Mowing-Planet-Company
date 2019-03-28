using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MowingPlanetCompany.StageScene
{
    public class PlayerAnimCtrl : MonoBehaviour
    {
        #region Variables
        /// <summary>鎌のコライダ</summary>
        [SerializeField] BoxCollider scytheCollider;
        /// <summary>mn_c_mainのノード</summary>
        [SerializeField] Transform mainNode;
        [SerializeField] float interpolate;

        /// <summary>アニメーションが始まる前のmn_c_mainノードのposition</summary>
        Vector3 beforeMainNodePosition = new Vector3();
        #endregion


        #region Methods

        private void Start()
        {
            // 鎌のコライダーをDesableにする
            scytheCollider.enabled = false;
            beforeMainNodePosition = mainNode.position;
        }

        /// <summary>
        /// 鎌のコライダーをActiveにする
        /// </summary>
        public void ActiveCollider()
        {
            Debug.Log("called ActiveCollider");
            scytheCollider.enabled = true;
        }

        /// <summary>
        /// 鎌のコライダーをDeactiveにする
        /// </summary>
        public void DeactiveCollider()
        {
            Debug.Log("called DeactiveCollider");
            scytheCollider.enabled = false;
        }

        ///// <summary>
        ///// アニメーションが始まったフレームのmain nodeの座標を代入
        ///// </summary>
        //public void StoreBeforePosition()
        //{
        //    Debug.Log(" StoreBeforePosition");
        //    beforeMainNodePosition = mainNode.position;
        //}

        ///// <summary>
        ///// アニメーションが終わる時にアニメ開始前との差分を取り、ずれた座標の修正を行う
        ///// </summary>
        //public void PositionCorrection()
        //{
        //    Debug.Log(" PositionCorrection");
        //    var offset = mainNode.position - beforeMainNodePosition;
        //    offset = new Vector3(0f, 0f, offset.z);
        //    Debug.Log(mainNode.position);
        //    mainNode.position -= offset;
        //    Debug.Log(mainNode.position);
        //    gameObject.transform.position += offset;
        //}
        #endregion
    }
}
