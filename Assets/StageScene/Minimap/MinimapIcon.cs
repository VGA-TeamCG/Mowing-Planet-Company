using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MowingPlanetCompany.StageScene
{
    /// <summary>
    /// 
    /// </summary>
    public class MinimapIcon : MonoBehaviour
    {
        /// <summary>同期するオブジェクト</summary>
        public MinimapObject Target;
        /// <summary></summary>
        public RectTransform RectTransform;
        /// <summary></summary>
        private Image image;

        /// <summary>
        /// 
        /// </summary>
        private void OnEnable()
        {
            image = GetComponent<Image>();

            RectTransform = GetComponent<RectTransform>();

            if(Target.Config.Icon != null)
            {
                image.sprite = Target.Config.Icon;
            }

            image.color = Target.Config.Color;
        }
    }
}
