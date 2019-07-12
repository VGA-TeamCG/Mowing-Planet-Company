using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace MowingPlanetCompany
{
    public class CountDownGameStart : MonoBehaviour
    {
        [TextArea(0, 2)]
        [SerializeField] List<string> displayScript;

        TypefaceAnimator typefaceAnim;
        Text textBox;

        private void Awake()
        {
            typefaceAnim = GetComponent<TypefaceAnimator>();
            textBox = GetComponent<Text>();
        }

        private void Start()
        {
            typefaceAnim.onComplete.AddListener(() =>
            {
                // 次のtextが存在する場合
                if (displayScript.IndexOf(textBox.text) + 1 < displayScript.Count)
                {
                    textBox.text = displayScript[displayScript.IndexOf(textBox.text) + 1];
                    typefaceAnim.Play();
                }
                else
                {

                }
            });


            textBox.text = displayScript[0];
            typefaceAnim.Play();
            for (int index = 0; index < displayScript.Count; index++)
            {
                // 次のtextが存在する場合
                if (index + 1 < displayScript.Count)
                {
                    typefaceAnim.onComplete.AddListener(() =>
                    {
                        typefaceAnim.onComplete.RemoveAllListeners();
                        textBox.text = displayScript[index + 1];
                    });
                }
            }
            //StartCoroutine(CountDownAnimation());
        }

        IEnumerator CountDownAnimation()
        {
            for (int index = 0; index < displayScript.Count; index++)
            {
                // 次のtextが存在する場合
                if (index + 1 < displayScript.Count)
                {
                    typefaceAnim.onComplete.AddListener(() =>
                    {
                        typefaceAnim.onComplete.RemoveAllListeners();
                        textBox.text = displayScript[index + 1];
                    });
                }
            }
        }
    }
}
