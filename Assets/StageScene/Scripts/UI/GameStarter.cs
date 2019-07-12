using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MowingPlanetCompany.StageScene
{
    public class StartGameButton : MonoBehaviour
    {
        [SerializeField] GameObject gameStartUI;
        [SerializeField] float animTIme = 1f;
         [SerializeField] iTween.EaseType easetype;

        public void StartGame()
        {
            TimeManager.Instance.StartCountDown();
            gameStartUI.SetActive(false);
        }

        public void VisibleGameStartDisplay()
        {
            var hash = new Hashtable()
            {
                {"from",0f },
                {"to",1f },
                {"time",animTIme },
                {"easetype",easetype },
            };

            gameStartUI.SetActive(true);
            iTween.ValueTo(gameStartUI, hash);
        }
    }
}
