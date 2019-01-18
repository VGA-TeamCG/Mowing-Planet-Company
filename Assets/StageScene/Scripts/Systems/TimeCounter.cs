﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MowingPlanetCompany.StageScene
{
    /// <summary>
    /// Time counter.
    /// </summary>
    public class TimeCounter : MonoBehaviour
    {
        /// <summary>hour</summary>
        [SerializeField] int m_hour;
        /// <summary>minute</summary>
        [SerializeField] int m_minute;
        /// <summary>seconds</summary>
        [SerializeField] float m_seconds;
        /// <summary>time scale</summary>
        [Range(0, 5)] [SerializeField] float m_timeScale = 1;
        [SerializeField] Text m_totalTimeText;

        /// <summary>
        /// トータル経過時刻
        /// </summary>
        /// <value>total time.</value>
        public float m_totalTime
        {
            get { return m_hour * 360f + m_minute * 60f + m_seconds; }
        }



        /// <summary>
        /// Update this instance.
        /// </summary>
        void Update()
        {
            Time.timeScale = m_timeScale; // 

            m_seconds += Time.deltaTime;
            if (m_seconds >= 60f) // やっている事は60進法の時計と一緒
            {
                m_minute++;
                m_seconds -= 60f;
            }
            if (m_minute >= 60)
            {
                m_hour++;
                m_minute -= 60;
            }
            m_totalTimeText.text = m_hour + ":" + m_minute + ":" + (int)m_seconds;
        }

        /// <summary>
        /// Gets the diff.
        /// </summary>
        /// <returns>The diff.</returns>
        /// <param name="time">Time.</param>
        public float GetDiff(float time)
        {
            return m_totalTime - time; // 開始時刻からトータル経過時刻の差分をとって経過時刻として返す
        }
    }
}