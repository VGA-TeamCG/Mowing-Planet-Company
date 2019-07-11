using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// リザルト画面で使うスクリプト
// 領収書の「明細書を見る」を押せば明細書に
// 明細書の「戻る」を押せば領収書になる

public class ChangeStatement : MonoBehaviour
{
    [SerializeField]GameObject receipt;
    [SerializeField]GameObject detailedStatement;
    bool isReceipt = true;

    void Start()
    {
        receipt.GetComponent<Canvas>().enabled = true;
        detailedStatement.GetComponent<Canvas>().enabled = false;
    }

    public void Change()
    {
        if (isReceipt)  // 「明細書を見る」ボタンを押せば、明細書を見るを表示する
        {
            isReceipt = false;
            receipt.GetComponent<Canvas>().enabled = false;
            detailedStatement.GetComponent<Canvas>().enabled = true;
        }
        else  //  「戻る」ボタンを押せば、領収書を表示する
        {
            isReceipt = true;
            receipt.GetComponent<Canvas>().enabled = true;
            detailedStatement.GetComponent<Canvas>().enabled = false;
        }
    }
}
