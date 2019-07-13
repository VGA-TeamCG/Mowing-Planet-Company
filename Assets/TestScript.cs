using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MowingPlanetCompany.StageScene
{
    public class TestScript : MonoBehaviour
    {
#if true
        [SerializeField] WorldStateMachine.States.State state;
        private void Update ()
        {
            Debug.Log($"Time.timeScale is {Time.timeScale}");
        }
#endif
    }
}
