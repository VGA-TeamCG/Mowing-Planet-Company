using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MowingPlanetCompany.StageScene
{
    public class MinimapCamera : MonoBehaviour
    {
        [Header("Components")]

        [SerializeField] Transform m_playerPosition;

        private void Update()
        {

            transform.gameObject.transform.position = m_playerPosition.position;
        }
    }
}
