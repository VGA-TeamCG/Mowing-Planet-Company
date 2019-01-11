using UnityEngine.EventSystems;

namespace MowingPlanetCompany.StageScene
{
    public interface ICommandHandler : IEventSystemHandler
    {
        void OnAttack();
    }
}