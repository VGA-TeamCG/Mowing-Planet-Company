using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MowingPlanetCompany.StageScene
{
    public class TestScript : MonoBehaviour
    {
        private void FixedUpdate()
        {
            transform.Rotate(Vector3.up, 90 * Time.deltaTime);
        }
    }
}
