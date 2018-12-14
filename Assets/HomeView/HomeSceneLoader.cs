using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeSceneLoader : MonoBehaviour
{
    /// <summary>
    /// シーンを切り替える
    /// </summary>
    public void TitleLoad()
    {
        Debug.Log("Title Loaded");
        SceneManager.LoadScene("Title");
    }
    public void TestLoad()
    {
        Debug.Log("Test Loaded");
        SceneManager.LoadScene("Test");
    }
    public void EquipLoad()
    {
        Debug.Log("Equip Loaded");
        SceneManager.LoadScene("Equip");
    }
}
