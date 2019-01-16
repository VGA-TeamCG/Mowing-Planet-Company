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

        #region Field

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


        [Header("Parameters")]

        /// <summary>初期化時に代入する分数</summary>
        [SerializeField] int m_setMinute;
        /// <summary>初期化時に代入する秒数</summary>
        [SerializeField] float m_setSeconds;
        /// <summary>time scale</summary>
        [Range(0, 5)] [SerializeField] float m_timeScale = 1;


        [Header("Components")]

        StageManager m_stageManager;
        /// <summary>残り時間を表示するテキスト</summary>
        [SerializeField] Text m_timeLimitText;


        /// <summary></summary>
        int m_minute;
        /// <summary></summary>
        float m_seconds;
        /// <summary></summary>
        float m_totalSeconds;
        /// <summary></summary>
        float m_oldSeconds;
        /// <summary>タイマーのスイッチングフラグ</summary>
        private bool m_toggle;

        #endregion
        #region Method
        /// <summary>
        /// 初期化
        /// </summary>
        public void Initialize()
        {
            m_minute = m_setMinute;
            m_seconds = m_setSeconds;
            m_totalSeconds = m_setMinute * 60 + m_setSeconds; // 単位を秒に変換
            m_oldSeconds = 0f;
        }

        private void Awake()
        {
            m_stageManager = StageManager.Instance;
        }

        private void Update()
        {
            if (Time.timeScale != m_timeScale)
            {
                Time.timeScale = m_timeScale;
            }
            if (!m_toggle)
            {
                return;
            }
            m_totalSeconds  -= Time.deltaTime;
        }
        #endregion
    }
}
