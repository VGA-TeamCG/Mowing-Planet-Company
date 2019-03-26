using System;
using System.Collections;
using System.Collections.Generic;
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

    // Use this for initialization
    void Start ()
    {
        // フィールドの初期値  何も数値が渡されなかったらここで指定した数値が表示される
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
}
