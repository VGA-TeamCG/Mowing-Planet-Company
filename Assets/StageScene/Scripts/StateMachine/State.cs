using UnityEngine;
using System.Collections;

public class State<T>
{
    /// <summary>このステートを使用するインスタンス</summary>
    protected T owner;
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="owner"></param>
    public State(T owner)
    {
        this.owner = owner;
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
