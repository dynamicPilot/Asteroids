using Leopotam.Ecs;
using UnityComponents.Common;
using UnityEngine;

namespace Systems.Spawners
{
    public class EnemySpawner : IEcsInitSystem, IEcsRunSystem
    {
        private StaticData _staticData;
        private SceneData _sceneData;
        private EcsWorld _world = null;

        private float _spawnDelay;
        private float _lastTime;

        public void Init()
        {
            _spawnDelay = _staticData.SpawnTimer;
        }

        public void Run()
        {
            _lastTime += Time.deltaTime;
            if (_lastTime > _spawnDelay)
            {
                _world.NewEntity().Get<SpawnPrefab>() = new SpawnPrefab
                {
                    Prefab = _staticData.AsteroidPrefab,
                    Position = _sceneData.AsteroidsContainer.position,
                    Rotation = Quaternion.identity,
                    Parent = _sceneData.AsteroidsContainer
                };

                _lastTime -= _spawnDelay;
            }
        }
    }
}

