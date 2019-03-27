using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MowingPlanetCompany.StageScene
{
    /// <summary>
    /// ミニマップのシステム
    /// </summary>
    public class MinimapSystem : MonoSingleton<MinimapSystem>
    {
        #region Field
        [Header("Components")]

        /// <summary>MinimapIconをプール(一時保存)しておく</summary>
        protected List<MinimapIcon> iconsPool = new List<MinimapIcon>();
        /// <summary>KeyにObject、値にIconを紐づけて格納</summary>
        protected Dictionary<MinimapObject, MinimapIcon> objectsIconsDict = new Dictionary<MinimapObject, MinimapIcon>();

        /// <summary>トラッキングする対象 : Focus target</summary>
        [SerializeField] protected Transform mapFocus;
        /// <summary>ミニマップのアイコン</summary>
        [SerializeField] protected RectTransform iconsRoot;
        /// <summary>MinimapIConのプレハブ</summary>
        [SerializeField] protected GameObject iconPrefab;

        /// <summary>Minimapのセンターの座標</summary>
        protected Vector3 minimapCenter
        {
            get { return iconsRoot.rect.center; }
        }

        [Header("Parameters")]

        /// <summary>Iconのセンターからの最大距離</summary>
        [SerializeField] protected float m_maxIconDistance = 100f;
        /// <summary>スケール</summary>
        [SerializeField] protected float m_scale = 1f;
        #endregion
        #region Method

        protected virtual void Update()
        {
            // 毎フレームプールされているアイコン全てに対して処理を行う
            // 1, ミニマップのセンターからの距離を測り、指定距離以内のアイコンのみ表示させる
            // 2, 設定されたスケール情報に応じた縮尺に変更する
            iconsPool.ForEach((icon) =>
            {
                icon.gameObject.SetActive(CheckVisibility(icon));

                icon.RectTransform.anchoredPosition = ConvertPosition(icon.Target.transform.position) * m_scale;
            });
        }

        /// <summary>
        /// minimapに表示するアイコンを登録する
        /// </summary>
        /// <param name="obj"></param>
        internal void RegisterMMObject(MinimapObject obj)
        {
            var icon = Construction(obj);
            iconsPool.Add(icon);
            objectsIconsDict.Add(obj, icon);
        }

        /// <summary>
        /// minimapに登録されているアイコンを削除する
        /// </summary>
        /// <param name="obj"></param>
        internal void UnRegisterMMObject(MinimapObject obj)
        {
            MinimapIcon icon;

            objectsIconsDict.TryGetValue(obj, out icon);

            if (!icon)
            {
                Debug.LogError("Trying to unregister icon that is not registered, how did this happen?");
                return;
            }

            iconsPool.Remove(icon);
        }


        /// <summary>
        /// 設定されてあるプレハブをもとにMinimapIconをもったゲームオブジェクトを生成する
        /// </summary>
        /// <param name="mmobj"></param>
        /// <returns></returns>
        protected virtual MinimapIcon Construction(MinimapObject mmobj)
        {
            if(!iconPrefab)
            {
                Debug.Log("Icon prefab is null , aborting icon construction.");
                return null;
            }

            iconPrefab.SetActive(false);

            var go = Instantiate(iconPrefab, iconsRoot, false);

            var icon = go.GetComponent<MinimapIcon>();

            icon.Target = mmobj;

            icon.gameObject.SetActive(true);
            iconPrefab.SetActive(true);

            return icon;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="icon"></param>
        /// <returns></returns>
        private bool CheckVisibility(MinimapIcon icon)
        {
            return Vector3.Distance(icon.RectTransform.anchoredPosition, Vector3.zero) < m_maxIconDistance;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        private Vector3 ConvertPosition(Vector3 position)
        {
            Vector3 transformed = mapFocus.transform.InverseTransformPoint(position);
            return new Vector3(transformed.x, transformed.z, 0f);
        }
        #endregion
    }
}
