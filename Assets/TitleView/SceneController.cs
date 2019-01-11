using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MowingPlanetCompany
{
    /// <summary>
    /// シーン遷移の関数群
    /// </summary>
    public class SceneController : MonoBehaviour
    {
        /// <summary>Title画面に切り替える</summary>
        public void TitleLoad()
        {
            Debug.Log("Title Loaded");
            SceneManager.LoadScene("Title");
        }

        /// <summary>Home画面に切り替える</summary>
        public void HomeLoad()
        {
            Debug.Log("Home Loaded.");
            SceneManager.LoadScene("Home");
        }

        /// <summary>設定画面に切り替える</summary>
        public void SettingLoad()
        {

            Debug.Log("Setting Loaded.");
            SceneManager.LoadScene("Setting");
        }

        /// <summary>Stage画面に切り替える</summary>
        public void StageLoad()
        {
            Debug.Log("Stage Loaded");
            SceneManager.LoadScene("Stage");
        }

        /// <summary>Equip画面に切り替える</summary>
        public void EquipLoad()
        {
            Debug.Log("Equip Loaded");
            SceneManager.LoadScene("Equip");
        }
    }
}