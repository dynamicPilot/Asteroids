using Components.Core;
using Components.Objects.Tags;
using Leopotam.Ecs;
using UnityComponents.Common;
using UnityEngine;

namespace Systems.Spawners
{
    public class BulletSpawner : IEcsRunSystem
    {
        private SceneData _sceneData;
        private EcsWorld _world = null;

        private EcsFilter<WeaponTag, MakeShoot> _filter = null;
        public void Run()
        {
            if (_filter.IsEmpty()) return;

            foreach(int index in _filter)
            {
                ref EcsEntity entity = ref _filter.GetEntity(index);
                WeaponTag tag = _filter.Get1(index);
                MakeShoot info = _filter.Get2(index);
                SpawnInBulletContainer(tag, info);
                entity.Del<MakeShoot>();

            }
        }

        void SpawnInBulletContainer(WeaponTag tag, MakeShoot info)
        {
            _world.NewEntity().Get<SpawnPrefabWithVelocity>() = new SpawnPrefabWithVelocity
            {
                Prefab = tag.Data.BulletPrefab,
                Position = info.PlayerContainer.position,
                Rotation = info.PlayerContainer.rotation,
                Parent = _sceneData.BulletsContainer,
                Velocity = info.Velocity * tag.Data.VelocityMagnitude
            };
        }
    }
}
