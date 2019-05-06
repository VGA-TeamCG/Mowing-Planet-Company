using UnityEngine.EventSystems;

namespace MowingPlanetCompany.StageScene
{
    public interface IMovable : IEventSystemHandler
    {
        void Move();
        void Idle();
    }
}