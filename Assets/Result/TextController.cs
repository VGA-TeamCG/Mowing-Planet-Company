using System;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    /// <summary> 領収書のナンバーテキスト </summary>
    [SerializeField] Text m_number;
    /// <summary> 領収書の日付テキスト </summary>
    [SerializeField] Text m_date;
    /// <summary> 領収書の会社名テキスト </summary>
    [SerializeField] Text m_companyName;
    /// <summary> 領収書の金額テキスト </summary>
    [SerializeField] Text m_amount;

    /// <summary> 明細書のノーマル草テキスト </summary>
    [SerializeField] Text m_normal;
    /// <summary> 明細書のニゲニゲ草テキスト </summary>
    [SerializeField] Text m_nigenige;
    /// <summary> 明細書のパクパク花テキスト </summary>
    [SerializeField] Text m_pakupaku;
    /// <summary> 明細書のツキツキ樹テキスト </summary>
    [SerializeField] Text m_tsukitsuki;
    /// <summary> 明細書のタイムボーナステキスト </summary>
    [SerializeField] Text m_timeBonus;
    /// <summary> 明細書のコンボボーナステキスト </summary>
    [SerializeField] Text m_comboBonus;
    /// <summary> 明細書の合計テキスト </summary>
    [SerializeField] Text m_sum;

    //MowingPlanetCompany.StageScene.ScoreManager scoreManager;

    void Start ()
    {
        // フィールドの初期値  
        // 何も数値が渡されなかったらここで指定した数値が表示される
        m_number.text = "No. " + "00";
        m_date.text = DateTime.Now.ToString("yyyy年MM月dd日");
        m_companyName.text = "MowingPlanetCompany";
        m_amount.text = "金額 : "　+ "$ "+"5000" + "-";
        m_normal.text = "ノーマル草 : " + "10" + " × " + "00" + "体" + " = " + "00000" + " p";
        m_nigenige.text = "ニゲニゲ草 : " + "100" + " × " + "00" + "体" + " = " + "00000" + " p";
        m_pakupaku.text = "パクパク花 : " + "500" + " × " + "00" + "体" + " = " + "00000" + " p";
        m_tsukitsuki.text = "ツキツキ樹 : " + "1000" + " × " + "00" + "体" + " = " + "00000" + " p";
        m_timeBonus.text = "タイムボーナス : " + "100" + " p " + " × " + "000.0" + " 秒" + " = " + "00000" + " p";
        m_comboBonus.text = "コンボボーナス : " + "00" + " p " + " × " + "000" + " コンボ " + " = " + "00000" + " p";
        m_sum.text = "合計 : " + "000000" + " p";
    }

    // ゲーム終了時に呼ばれる
    public void SetValue(int NormalGrassPerPoint,    int NormalGrassCount,    int NormalGrassScore,
                         int NigenigeGrassPerPoint,  int NigenigeGrassCount,  int NigenigeGrassScore,
                         int PakupakuFlowerPerPoint, int PakupakuFlowerCount, int PakupakuFlowerScore,
                         int TukiTukiWoodPerPoint,   int TukiTukiWoodCount,   int TukiTukiWoodScore,
                         
                         int ComboPerPoint,          int ComboScore,
                         int TotalScore)
    {
        m_number.text = "No. " + UnityEngine.Random.Range(1, 100);
        m_date.text = DateTime.Now.ToString("yyyy年MM月dd日");
        m_companyName.text = "MowingPlanetCompany";  // 会社名は後ほど考える

        m_amount.text = "金額 : " + "$ " + TotalScore + "-";
        m_normal.text = "ノーマル草 : " + NormalGrassPerPoint + " × " + NormalGrassCount + "体" + " = " + NormalGrassScore + " p";
        m_nigenige.text = "ニゲニゲ草 : " + NigenigeGrassPerPoint + " × " + NigenigeGrassCount + "体" + " = " + NigenigeGrassScore + " p";
        m_pakupaku.text = "パクパク花 : " + PakupakuFlowerPerPoint + " × " + PakupakuFlowerCount + "体" + " = " + PakupakuFlowerScore + " p";
        m_tsukitsuki.text = "ツキツキ樹 : " + TukiTukiWoodPerPoint + " × " + TukiTukiWoodCount + "体" + " = " + TukiTukiWoodScore + " p";
        m_timeBonus.text = "タイムボーナス : " + /*TimePerPoint*/00 + " p " + " × " + "000.0" + " 秒" + " = " + /*TimeScore*/00 + " p";
        m_comboBonus.text = "コンボボーナス : ";  //コンボボーナスはコンボ計算ができてから
        m_sum.text = "合計 : " + TotalScore + " p";
    }
}
