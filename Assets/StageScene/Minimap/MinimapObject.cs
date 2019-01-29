using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MowingPlanetCompany.StageScene
{
    public class MinimapObject : MonoBehaviour
    {
        [SerializeField] private Configuration config = new Configuration();

        public Configuration Config
        {
            get { return config; }
        }

        [System.Serializable]
        public class Configuration
        {
            public Sprite Icon;
            public Color Color = Color.white;
        }

        protected virtual void OnEnable()
        {
            MinimapSystem.Instance.RegisterMMObject(this);
        }

        protected virtual void OnDisable()
        {
            MinimapSystem.Instance.UnRegisterMMObject(this);
        }
    }
}

