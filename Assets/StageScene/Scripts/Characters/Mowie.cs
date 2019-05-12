using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MowingPlanetCompany
{
    public class Mowie : MonoBehaviour
    {
        #region Properties
        public Status MyStatus { get { return status; } set { status = value; } }
        #endregion

        #region Variables
        [SerializeField] Status status;
        #endregion
    }
}

