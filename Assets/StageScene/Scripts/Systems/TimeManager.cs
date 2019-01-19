using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MowingPlanetCompany.StageScene
{

    /// <summary>
    /// 時間管理クラス
    /// </summary>
    public class TimeManager : MonoSingleton<TimeManager>
    {

        #region Property
        /// <summary>タイマーのスイッチングフラグ</summary>
        public bool Toggle
        {
            get
            { return m_toggle; }
            set
            {
                if (m_stageManager.m_StteMachine.m_state == StageManager.StateMachine.State.InTheGame) // InTheGameのステートの時だけ代入可能
                {
                    m_toggle = value;
                }
                else
                {
                    Debug.LogWarning("State がInTheGameの時だけ代入可能です");
                }
            }
        }



        #endregion
        #region Field
        /// <summary>イベントに使用するデリゲート</summary>
        public delegate void CountDownEvent();

        /// <summary>カウントダウン開始時に発行されるイベント</summary>
        public static event CountDownEvent OnStartCountDown;
        /// <summary>カウントダウン中毎フレーム発行されるイベント</summary>
        public static event CountDownEvent OnDuringCountDown;
        /// <summary>カウントダウン終了時に発行されるイベント</summary>
        public static event CountDownEvent OnEndCountDown;


        [Header("Parameters")]

        /// <summary>初期化時に代入する分数</summary>
        [SerializeField] int m_setMinute;
        /// <summary>初期化時に代入する秒数</summary>
        [SerializeField] float m_setSeconds;

        [Header("Components")]

        StageManager m_stageManager;
        /// <summary>残り時間を表示するテキスト</summary>
        [SerializeField] Text m_timerText;


        /// <summary>残り分数</summary>
        int m_minute;
        /// <summary>残り秒数</summary>
        float m_seconds;
        /// <summary></summary>
        float m_totalSeconds;
        /// <summary>タイマーのスイッチングフラグ</summary>
        bool m_toggle;

        #endregion
        #region Method

        private void Awake()
        {
            m_stageManager = StageManager.Instance;
        }

        private void Update()
        {
            if (m_toggle)
            {
                DuringCountDown();
            }
        }

        /// <summary>
        /// 初期化
        /// </summary>
        public void InitTimer()
        {
            m_minute = m_setMinute;
            m_seconds = m_setSeconds;
            m_totalSeconds = m_setMinute * 60 + m_setSeconds; // 単位を秒に変換
        }


        /// <summary>
        /// カウントダウン開始
        /// </summary>
        public void StartCountDown()
        {
            InitTimer();
            m_toggle = true;

            // =============
            // カウントダウン開始時のイベントコール : Event Call that "OnStartCountDown()"
            // =============
            if (OnStartCountDown != null)
                OnStartCountDown();
        }

        /// <summary>
        /// カウントダウンが行われている間の処理
        /// </summary>
        void DuringCountDown()
        {
            // =============
            // カウントダウン中のイベントコール : Event Call that "OnDuringCountDown()"
            // =============
            if (OnDuringCountDown != null)
                OnDuringCountDown();

            //  カウントダウン処理を行う. 残り時間が無くなったら終了しイベントを発行する
            m_seconds -= Time.deltaTime;
            if (m_seconds <= 0)
            {
                if (m_minute == 0)
                {
                    m_seconds = 0;
                    DisplayText();
                    m_toggle = false;
                    OnEndCountDown();
                }

                if (m_minute > 0)
                {
                    m_minute--;
                    m_seconds += 60;
                    DisplayText();
                }
            }
        }

        /// <summary>
        /// 画面にテキスト表示を行う
        /// </summary>
        void DisplayText()
        {
            m_timerText.text = "あと" + m_minute + "分" + (int)m_seconds + "秒";
        }
        #endregion
    }
}
