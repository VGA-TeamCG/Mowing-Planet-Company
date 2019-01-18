using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstronomicalObject : MonoBehaviour
{
    public ParticleSystem[] shootingStars;    //インスペクタから使用するパーティクルのオブジェクトを７個分セットしておく

    // Use this for initialization
    void Start ()
    {
        MakeParticle();
	}
	
    void MakeParticle()
    {
        int count = Random.Range(4, 8);    //生成する個数（intの場合は後ろの数字は含まれないので+1する）
        float x, y, z;    //場所指定用の変数

        //生成する個数分繰り返す
        for (int i = 0; i < count + 1; i++)
        {
            //ランダムな座標を作成（floatの場合は後ろの数字も含む）
            x = Random.Range(-50.0f, 50.0f);
            y = Random.Range(100.0f, 120.0f);
            z = Random.Range(-50.0f, 50.0f);

            //パーティクルのオブジェクトの位置を移動してからパーティクル再生
            shootingStars[i].transform.position = new Vector3(x, y, z);
            shootingStars[i].Play();
        }
    }
}
