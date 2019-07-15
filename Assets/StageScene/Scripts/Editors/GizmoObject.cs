using UnityEngine;
using System.Collections;

namespace MowingPlanetCompany.StageScene
{
    public class GizmoObject : MonoBehaviour
    {
        /// <summary></summary>
        public float WidthAngle => widthAngle;
        /// <summary></summary>
        public float HeightAngle => heightAngle;
        /// <summary></summary>
        public float Length => length;
        /// <summary></summary>
        public Color Color => color;

        [SerializeField]
        [Range(0f, 360f)]
        float widthAngle = 365f;
        [SerializeField]
        [Range(0f, 360f)]
        float heightAngle = 0f;
        [SerializeField]
        [Range(0f, 360f)]
        float length = 1f;
        [SerializeField]
        Color color = new Color(.5f, .5f, .5f, .5f);

        /// <summary>
        /// Gizmoの表示範囲を設定する
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="length"></param>
        public void SetGizmo(float width, float height, float length)
        {
            SetGizmo(width, height, length, color);
        }
        /// <summary>
        /// Gizmoの表示色を設定する
        /// </summary>
        /// <param name="color"></param>
        public void SetGizmo(Color color)
        {
            SetGizmo(widthAngle, heightAngle, length, color);
        }
        /// <summary>
        /// Gizmoの表示範囲を設定する
        /// </summary>
        /// <param name="length"></param>
        public void SetGizmo(float length)
        {
            SetGizmo(widthAngle, heightAngle, length, color);
        }
        /// <summary>
        /// Gizmoの表示範囲とその色を設定する
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="length"></param>
        /// <param name="color"></param>
        public void SetGizmo(float width, float height, float length, Color color)
        {
            widthAngle = width;
            heightAngle = height;
            this.length = length;
            this.color = color;
        }

        private void Update()
        {
            transform.up = Vector3.up;
        }
    }
}