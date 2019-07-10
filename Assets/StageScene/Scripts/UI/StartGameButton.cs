using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MowingPlanetCompany.StageScene
{
    public class StartGameButton : MonoBehaviour
    {
        void StartGame()
        {
            TimeManager.Instance.StartCountDown();
            gameObject.SetActive(false);
        }
    }
}
