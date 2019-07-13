using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MowingPlanetCompany.StageScene
{
    /// <summary>
    /// Score manager
    /// </summary>
    public class ScoreManager : MonoBehaviour
    {
        #region Properties
        /// <summary>ノーマル草の一体毎のポイント</summary>
        public int NormalGrassPerPoint { get; set; }
        /// <summary>ノーマル草を何体倒したか</summary>
        public int NormalGrassCount { get; set; }
        /// <summary>ノーマル草のスコア</summary>
        public int NormalGrassScore { get; set; }
        /// <summary>ニゲニゲ草の一体毎のポイント</summary>
        public int NigenigeGrassPerPoint { get; set; }
        /// <summary>ニゲニゲ草を何体倒したか</summary>
        public int NigenigeGrassCount { get; set; }
        /// <summary>ニゲニゲ草のスコア</summary>
        public int NigenigeGrassScore { get; set; }
        /// <summary>パクパク花の一体毎のポイント</summary>
        public int PakupakuFlowerPerPoint { get; set; }
        /// <summary>パクパク花を何体倒したか</summary>
        public int PakupakuFlowerCount { get; set; }
        /// <summary>パクパク花のスコア</summary>
        public int PakupakuFlowerScore { get; set; }
        /// <summary>ツキツキ樹の一体毎のポイント</summary>
        public int TsukiTsukiWoodPerPoint { get; set; }
        /// <summary>ツキツキ樹を何体倒したか</summary>
        public int TsukiTsukiWoodCount { get; set; }
        /// <summary>ツキツキ樹のスコア</summary>
        public int TsukiTsukiWoodScore { get; set; }
        /// <summary>タイム(現状１秒)毎のポイント</summary>
        public int TimePerPoint { get; set; }
        /// <summary>タイムスコア</summary>
        public int TimeScore { get; set; }
        /// <summary>コンボ毎のポイント</summary>
        public int ComboPerPoint { get; set; }
        /// <summary>コンボスコア</summary>
        public int ComboScore { get; set; }
        /// <summary>トータルスコア</summary>
        public int TotalScore { get; set; }
        #endregion

        #region Methods
        //public void AddScore
        #endregion

        #region Enums

        #endregion
        [SerializeField] TextController tc;
        void Start()
        {
            tc = gameObject.GetComponent<TextController>();
        }

        /// <summary>ノーマル草のスコア計算</summary>
        public void CalculateNormalGrassScore()
        {
            NormalGrassCount++;
            NormalGrassScore += NormalGrassPerPoint;
        }

        /// <summary>ニゲニゲ草のスコア計算</summary>
        public void CalculateNigenigeGrassScore()
        {
            NormalGrassCount++;
            NigenigeGrassScore += NigenigeGrassPerPoint;
        }

        /// <summary>パクパク花のスコア計算</summary>
        public void CalculatePakupakuFlowerScore()
        {
            PakupakuFlowerCount++;
            PakupakuFlowerScore += PakupakuFlowerPerPoint;
        }

        /// <summary>ツキツキ樹のスコア計算</summary>
        public void CalculateTukiTukiWoodScore()
        {
            TsukiTsukiWoodCount++;
            TsukiTsukiWoodScore += TsukiTsukiWoodPerPoint;
        }

        /// <summary>タイムスコアの計算</summary>
        public void CalculateTimeScore()
        {
            TimeScore = TimePerPoint /*leftTime*/;  // 残り時間を「TimeManager」から参照する(もらう)
        }

        /// <summary>コンボスコアの計算</summary>
        public void CalculateComboScore()
        {
            // 後で実装する
            // 全合計スコアにコンボボーナスを掛ける
        }

        /// <summary>トータルスコアの計算</summary>
        public void CalculateTotalScore()
        {
            TotalScore = ComboScore;
        }

        public void SetScoreToText()  // 残り時間を「TimeManager」から参照する(もらう)
        {
            tc.SetValue(NormalGrassPerPoint, NormalGrassCount, NormalGrassScore,
                        NigenigeGrassPerPoint, NigenigeGrassCount, NigenigeGrassScore,
                        PakupakuFlowerPerPoint, PakupakuFlowerCount, PakupakuFlowerScore,
                        TsukiTsukiWoodPerPoint, TsukiTsukiWoodCount, TsukiTsukiWoodScore,
                        ComboPerPoint, ComboScore,
                        TotalScore);
        }
    }
}
