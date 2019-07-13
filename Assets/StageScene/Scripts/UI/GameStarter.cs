using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace MowingPlanetCompany.StageScene
{
    public class GameStarter : MonoBehaviour
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
                    // call event
                    WorldStateMachine.Instance.SetStateMachine(WorldStateMachine.States.State.InTheGame);
                    textBox.text = "";
                    Destroy(transform.parent.gameObject);
                }
            });
        }
        /// <summary>
        /// Count downの演出を行った後、
        /// </summary>
        public void StartCountDown()
        {
            if (textBox != null)
            {
                textBox.text = displayScript[0];
                typefaceAnim.Play();
            }
        }
    }
}
