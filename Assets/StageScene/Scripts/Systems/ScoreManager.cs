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
        /// <summary>ノーマル草のスコア</summary>
        public int NormalGrassScore { get; set; }
        /// <summary>ニゲニゲ草の一体毎のポイント</summary>
        public int NigenigeGrassPerPoint { get; set; }
        /// <summary>ニゲニゲ草のスコア</summary>
        public int NigenigeGrassScore { get; set; }
        /// <summary>パクパク花の一体毎のポイント</summary>
        public int PakupakuFlowerPerPoint { get; set; }
        /// <summary>パクパク花のスコア</summary>
        public int PakupakuFlowerScore { get; set; }
        /// <summary>ツキツキ樹の一体毎のポイント</summary>
        public int TukiTukiWoodPerPoint { get; set; }
        /// <summary>ツキツキ樹のスコア</summary>
        public int TukiTukiWoodScore { get; set; }
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
    }
}
