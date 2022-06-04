using Components.Common.MonoLinks;
using Components.Core;
using Components.Objects;
using Components.Objects.Moves;
using Components.Objects.Tags;
using Components.PhysicsEvents;
using Leopotam.Ecs;
using UnityComponents.MonoLinks;
using UnityEngine;

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
                var teleportingObject = colliderGameObject.GetComponent<TeleportTagMonoLink>();

                if (teleportingObject == null)
                {
                    Debug.Log("No Teleport");
                    continue;
                }

                Debug.Log("Teleport is here");
                entity.Get<TeleportingTag>() = new TeleportingTag { Value = SIDE.down };
            }
        }
    }

}
