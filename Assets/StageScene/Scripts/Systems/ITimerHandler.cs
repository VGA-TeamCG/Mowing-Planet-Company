using UnityEngine.EventSystems;

namespace MowingPlanetCompany.StageScene
{
    public interface ITimerHandler : IEventSystemHandler 
    {
        void OnCountDownEntry();
        void OnCountDownStay();
        void OnCountDownEnded();
    }
}