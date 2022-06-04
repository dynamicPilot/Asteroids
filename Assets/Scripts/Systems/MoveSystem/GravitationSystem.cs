using Components.Objects.Moves;
using Leopotam.Ecs;
using UnityComponents.Common;
using UnityEngine;

namespace Systems.MoveSystems
{
    public class GravitationSystem : IEcsRunSystem
    {
        private StaticData _staticData;
        private EcsFilter<Gravitational> _filter = null;

        public void Run()
        {
            // update or fixed update
            var deltaTime = Time.fixedTime;

            foreach(int index in _filter)
            {
                ref EcsEntity entity = ref _filter.GetEntity(index); // get entity from filter
                ref Velocity velocity = ref entity.Get<Velocity>(); // get velocity from entity

                Vector3 addVelocity = _staticData.GlobalGravitation * deltaTime;
                velocity.Value += addVelocity;
            }
        }
    }
}

