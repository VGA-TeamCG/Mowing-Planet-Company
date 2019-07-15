using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace MowingPlanetCompany.StageScene
{
    public abstract class StatefulObjectBase<T, TEnum> : MonoBehaviour
        where T : class where TEnum : System.IConvertible
    {
        protected List<State<T, TEnum>> stateList = new List<State<T, TEnum>>();
        protected StateMachine<T, TEnum> stateMachine = new StateMachine<T, TEnum>();

        public virtual void ChangeState(TEnum nextState)
        {
            if (stateMachine == null)
            {
                return;
            }
            var targetState = stateList.Find(state => state.Identity.ToInt32(null) == nextState.ToInt32(null));
            stateMachine.ChangeState(targetState);
        }

        public virtual bool IsCurrentState(TEnum identity)
        {
            if (stateMachine == null)
            {
                return false;
            }
            return stateMachine.CurrentState.Identity.Equals(identity);
        }

        protected virtual void Update()
        {
            if (stateMachine != null)
            {
                stateMachine.Update();
            }
        }
    }
}