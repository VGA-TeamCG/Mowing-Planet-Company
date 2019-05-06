using UnityEngine.EventSystems;

namespace MowingPlanetCompany.StageScene
{
    public interface IEnemy
    {
        void OnCollideAttack();
        void OnCollidePlayer();
    }
}