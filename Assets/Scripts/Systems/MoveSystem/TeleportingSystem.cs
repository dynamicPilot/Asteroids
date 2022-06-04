using Components.Objects;
using Components.PhysicsEvents;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems.MoveSystems
{
    public class TeleportingSystem : IEcsRunSystem
    {
        private EcsFilter<TeleportingTag, OnTriggerExit2DEvent> _filter = null;
        public void Run()
        {
            if (_filter.IsEmpty())
            {
                return;
            }

            foreach (int index in _filter)
            {
                ref EcsEntity entity = ref _filter.GetEntity(index);
                var side = _filter.Get1(index).Value;
                ref Position position = ref entity.Get<Position>();
                
                if (side == SIDE.up || side == SIDE.down)
                {
                    Debug.Log("Teleporting...");
                    position.Value = new Vector3(position.Value.x, position.Value.y * -1, position.Value.z);
                }
                else if (side == SIDE.left || side == SIDE.right)
                {
                    position.Value = new Vector3(position.Value.x * -1, position.Value.y, position.Value.z);
                }

                entity.Del<TeleportingTag>();

            }
        }
    }
}

