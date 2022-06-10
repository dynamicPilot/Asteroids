using Components.Common.MonoLinks;
using Components.Objects;
using Components.Objects.Moves;
using Leopotam.Ecs;
using UnityComponents.Common;
using UnityEngine;

namespace Systems.MoveSystems
{
    public class MoveSystem : IEcsRunSystem
    {
        private StaticData _staticData;
        private EcsFilter<Velocity> _filter = null;

        public void Run()
        {
            // update or fixed update
            foreach (int index in _filter)
            {
                ref EcsEntity entity = ref _filter.GetEntity(index); // get entity from filter
                ref Position position = ref entity.Get<Position>(); // get position from entity
                //Velocity velocity = _filter.Get1(index);

                ref Velocity velocity = ref entity.Get<Velocity>();
                
                if (velocity.Acceleration == null) velocity.Acceleration = Vector3.zero;

                position.Value += velocity.Value * Time.fixedDeltaTime + velocity.Acceleration * Time.fixedDeltaTime * Time.fixedDeltaTime / 2;
                velocity.Value += velocity.Acceleration * Time.fixedDeltaTime;

                if (velocity.Value.magnitude < _staticData.VelocitySensitivity) velocity.Value = Vector3.zero;
            }

        }
    }
}

