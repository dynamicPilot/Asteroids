using Components.Common.MonoLinks;
using Components.Core;
using Components.Objects;
using Components.Objects.Moves;
using Components.Objects.Tags;
using Components.PhysicsEvents;
using Leopotam.Ecs;
using UnityComponents.MonoLinks;
using UnityComponents.MonoLinks.UnityBaseComponents;
using UnityEngine;
using Utilities.Teleporting;

namespace Systems.CoreSystems.Teleport
{
    public class TeleportTriggerCheckerSystem : IEcsRunSystem
    {
        private EcsWorld _world = null;
        private EcsFilter<GameObjectLink, OnTriggerExit2DEvent> _filter = null;
        public void Run()
        {
            if (_filter.IsEmpty())
            {
                return;
            }

            foreach (int index in _filter)
            {
                ref EcsEntity entity = ref _filter.GetEntity(index);
                var OnTriggerExit2DEvent = entity.Get<OnTriggerExit2DEvent>();

                GameObject colliderGameObject = OnTriggerExit2DEvent.Collider.gameObject;
                var teleportTag = colliderGameObject.GetComponent<TeleportTagMonoLink>();
                var boxColliderTag = colliderGameObject.GetComponent<BoxCollider2DMonoLink>();

                if (teleportTag == null || boxColliderTag == null)
                {
                    // no teleport or teleport without box collider
                    continue;
                }

                // get side
                GameObjectLink selfObjectLink = _filter.Get1(index);
                entity.Get<TeleportingTag>() = new TeleportingTag { Value = GetContactSide(colliderGameObject, selfObjectLink) };
            }
        }

        private SIDE GetContactSide(GameObject teleportObject, GameObjectLink selfObjectLink)
        {
            return BoxSideCalculatorUtility.CalculateSideOfBoxWhenContact(teleportObject.GetComponent<BoxCollider2D>().size,
                selfObjectLink.Value.transform.position);
        }
    }

}
