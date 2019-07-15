using UnityEngine;
using System.Collections;
namespace MowingPlanetCompany.StageScene
{
    public class StateStop<T> : State<T, GrassState> where T : GrassesBase<T>
    {
        float changeStateTime;
        public StateStop(T owner, GrassState identity) : base(owner, identity) { }

        public override void Enter()
        {
            base.Enter();
            changeStateTime = Random.Range(1, 5);
        }
        public override void Execute()
        {
            if (ElapsedTimeSinseStateStart > changeStateTime)
            {
                owner.ChangeState(GrassState.Wander);
            }
        }
        public override void Exit() { }
    }
}