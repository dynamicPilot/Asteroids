using Components.Core;
using Components.Objects.Tags;
using Components.PhysicsEvents;
using Leopotam.Ecs;
using UnityComponents.MonoLinks;
using UnityEngine;

namespace Systems.CoreSystems.BaseGameplay
{
    public class EnemyCollisionCheckerSystem : IEcsRunSystem
    {
        private EcsWorld _world = null;
        private EcsFilter<PlayerTag, OnCollisionEnter2DEvent> _filter = null;

        public void Run()
        {
            if (_filter.IsEmpty())
            {
                return;
            }

            foreach (int index in _filter)
            {
                ref EcsEntity entity = ref _filter.GetEntity(index);
                var onCollisionEnterEvent = entity.Get<OnCollisionEnter2DEvent>();

                GameObject collisionGameObject = onCollisionEnterEvent.Collision.gameObject;
                var obstacle = collisionGameObject.GetComponent<EnemyTagMonoLink>();
                
                if (obstacle == null)
                    continue;

                EcsEntity obstacleCollision = _world.NewEntity();
                obstacleCollision.Get<OnEnemyCollisionEvent>();
            }
        }
    }

}
