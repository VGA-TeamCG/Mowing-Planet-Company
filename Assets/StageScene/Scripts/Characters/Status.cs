using System;
using UnityEngine;
using System.Collections;

[Serializable]
public class Status
{
    public int Life;
    public int MaxLife;
    public int Atk;
    public int Speed;

    public void Initialize()
    {
        Life = MaxLife;
    }
}
