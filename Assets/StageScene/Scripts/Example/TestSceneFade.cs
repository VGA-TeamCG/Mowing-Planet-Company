using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MowingPlanetCompany;
public class TestSceneFade : MonoBehaviour
{


    public void OnFadeButton()
    {
        SceneFader sceneFader = SceneFader.Instance;
        sceneFader.FadeOut(SceneFader.SceneTitle.Home);
    }
}
