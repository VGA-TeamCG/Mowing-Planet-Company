using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace MowingPlanetCompany.StageScene
{
    public abstract class StatefulObjectBase<T, TEnum> : MonoBehaviour
        where T : class where TEnum : System.IConvertible
    {
        protected List<State<T>> stateList = new List<State<T>>();
        protected StateMachine<T> stateMachine=new StateMachine<T>();

        public virtual void ChangeState(TEnum state)
        {
            if (stateMachine == null)
            {
                return;
            }
            Debug.Log(string.Format("go is {0}. state index is {1}", gameObject.name,state.ToInt32(null).ToString()));
            stateMachine.ChangeState(stateList[state.ToInt32(null)]);
        }

        public virtual bool IsCurrentState(TEnum state)
        {
            if (stateMachine == null)
            {
                return false;
            }
            return stateMachine.CurrentState == stateList[state.ToInt32(null)];
        }

        protected virtual void Update()
        {
            if(stateMachine != null)
            {
                stateMachine.Update();
            }
        }
    }
}