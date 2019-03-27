using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// このスクリプトはゲームシーンに配置する
// ゲームシーンからリザルト画面に引数を渡す
// DontDestroyOnLoad() を使ってゲームシーンでのスコアを保持する
// 保持したスコアはリザルト画面でスコアの処理をした後、破棄する

public class ScoreController : MonoBehaviour
{
    /// <summary> ノーマル草を何体倒したかを表す </summary>
    public int m_normalCount = 0;
    /// <summary> ニゲニゲ草を何体倒したかを表す </summary>
    public int m_nigenigeCount = 0;
    /// <summary> パクパク花を何体倒したかを表す </summary>
    public int m_pakupakuCount = 0;
    /// <summary> ツキツキ樹を何体倒したかを表す </summary>
    public int m_tsukitsukiCount = 0;

    /// <summary> 残り時間を表す </summary>
    public float m_timeLeft = 0.0f;

    /// <summary> 最大コンボを表す </summary>
    public int m_maxCombo = 0;

    /// <summary> シーン遷移してもこのオブジェクトが破棄されないようにする </summary>
    private void Start()
    {
        // このGameObjectを破棄しないようにする
        DontDestroyOnLoad(gameObject);
    }

    /// <summary> 敵を倒したときに呼ばれる　倒した数をカウントする </summary>
    public void Count()
    {

    }

    /// <summary> 最大コンボを取得する </summary>
    public void GetMaxCombo(int max)
    {
        m_maxCombo = max;
    }
 
    /// <summary> リザルト画面でスコア処理をした後にこの関数を呼び、破棄する </summary>
    public void Destroy()
    {
        // このGameObjectを破棄する
        Destroy(gameObject);
    }
}
