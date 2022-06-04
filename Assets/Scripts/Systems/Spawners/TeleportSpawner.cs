using Leopotam.Ecs;
using UnityComponents.Common;
using UnityEngine;

namespace Systems.Spawners
{
    public class TeleportSpawner : IEcsInitSystem
    {
        private EcsWorld _world = null;
        private StaticData _staticData;
        private SceneData _sceneData;

        public void Init()
        {
            // Start
            // Construct prefab and spawn it
            _world.NewEntity().Get<SpawnPrefab>() = new SpawnPrefab
            {
                Prefab = _staticData.TeleportPrefab,
                Position = _sceneData.TeleportContainer.position,
                Rotation = Quaternion.identity,
                Parent = _sceneData.TeleportContainer
            };
        }
    }
}


