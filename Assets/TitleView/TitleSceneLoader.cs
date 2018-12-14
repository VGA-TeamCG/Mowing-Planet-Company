using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSceneLoader : MonoBehaviour
{
    /// <summary>
    /// Homeシーンに切り替える
    /// </summary>
    public void Load()
    {
        Debug.Log("Home Loaded");
        SceneManager.LoadScene("Home");
    }
}
