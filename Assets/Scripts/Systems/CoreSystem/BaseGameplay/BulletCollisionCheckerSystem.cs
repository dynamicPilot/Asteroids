using Components.Common.MonoLinks;
using Components.Core;
using Components.Objects;
using Components.Objects.Tags;
using Components.PhysicsEvents;
using Leopotam.Ecs;
using UnityComponents.MonoLinks;
using UnityComponents.MonoLinks.Base;
using UnityComponents.MonoLinks.WeaponLinks;
using UnityEngine;

namespace Systems.CoreSystems.BaseGameplay
{
    public class BulletCollisionCheckerSystem : IEcsRunSystem
    {
        private EcsWorld _world = null;
        private EcsFilter<EnemyTag, OnCollisionEnter2DEvent> _filter = null;

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

                if (collisionGameObject.GetComponent<BulletTagMonoLink>() == null)
                {
                    continue;
                }

                if (_filter.Get1(index).CanBeDivided)
                {
                    Vector3 position = entity.Get<Position>().Value;
                    EcsEntity makeSmallEnemiesEvent = _world.NewEntity();
                    makeSmallEnemiesEvent.Get<MakeSmallEnemiesEvent>() = new MakeSmallEnemiesEvent { Position = position };
                }

                collisionGameObject.GetComponent<BulletMonoEntity>().DestroyMe();
                entity.Get<DestroyObject>();
            } 
        }
    }
}
