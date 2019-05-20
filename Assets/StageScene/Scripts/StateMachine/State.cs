using UnityEngine;
using System.Collections;
using MowingPlanetCompany.StageScene;
using System;

public class State<T,TEnum>
{
    /// <summary>このステートを使用するインスタンス</summary>
    public  T owner;
    /// <summary>識別子</summary>
    public TEnum identity;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="owner"></param>
    public State(T owner, TEnum identity)
    {
        this.owner = owner;
        this.identity = identity;
    }

    /// <summary>
    /// このステートに遷移する時に一度だけ呼ばれる
    /// </summary>
    public virtual void Enter() { }
    /// <summary>
    /// このステートで有る間、毎フレーム呼ばれる
    /// </summary>
    public virtual void Excute() { }
    /// <summary>
    /// このステートから他のステートに遷移する時に一度だけ呼ばれる
    /// </summary>
    public virtual void Exit() { }
}
