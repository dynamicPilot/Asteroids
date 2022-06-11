using Leopotam.Ecs;
using UnityComponents.Common;
using UnityEngine;

namespace Systems.Spawners
{
    public class BulletSpawner : IEcsInitSystem, IEcsRunSystem
    {
        private StaticData _staticData;
        private SceneData _sceneData;
        private EcsWorld _world = null;

        private float _shootingTimer;
        private float _startShootingTime;
        private int _bulletsNumber;

        public void Init()
        {
            
        }

        public void Run()
        {
            
        }

        void SpawnBullet()
        {
            //_world.NewEntity().Get<SpawnPrefab>() = new SpawnPrefab
            //{
            //    Prefab = _staticData.AsteroidPrefab,
            //    Position = SpawnerUtility.GetPositionToSpawn(_staticData),
            //    Rotation = Quaternion.identity,
            //    Parent = _sceneData.AsteroidsContainer
            //};
        }
    }
}
