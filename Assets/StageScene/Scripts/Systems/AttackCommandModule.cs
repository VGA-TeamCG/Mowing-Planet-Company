using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MowingPlanetCompany.StageScene
{
    /// <summary>
    /// Attack command.
    /// </summary>
    public class AttackCommandModule : BaseInputModule, IPointerDownHandler
    {
        /// <summary>Player</summary>
        [SerializeField] GameObject m_player;

        /// <summary>
        /// Ons the pointer down.
        /// </summary>
        /// <param name="eventData">Event data.</param>
        public void OnPointerDown(PointerEventData eventData)
        {
            ExecuteEvents.Execute<ICommandHandler>(
            target: m_player,
            eventData: new BaseEventData(eventSystem),
            functor: (commander, BaseEventData) => commander.OnAttack()
            );
        }

        /// <summary>
        /// Process this instance.
        /// </summary>
        public override void Process()
        {
            //Debug.Log("Called Process");
            //ExecuteEvents.Execute<ICommandHandler>(
            //target: m_player,
            //eventData: new BaseEventData(eventSystem),
            //functor: (commander, eventData) => commander.OnAttack()
           //);
        }
    }
}
