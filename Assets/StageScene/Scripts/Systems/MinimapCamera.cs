using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MowingPlanetCompany.StageScene
{
    public class MinimapCamera : MonoBehaviour
    {
        [Header("Components")]

        [SerializeField] Transform m_playerPosition;
        [SerializeField] float m_offset = 10f;
        Vector3 vec;

        private void Update()
        {
            vec = m_playerPosition.position;
            vec.y = vec.y + m_offset;
            transform.gameObject.transform.position = vec;
        }
    }
}
