using UnityEngine;
using Leopotam.Ecs;
using UnityComponents.Common;
using UnityComponents.MonoLinks.Base;

namespace Systems.Spawners
{
    /// <summary>
    /// Spawn Player
    /// </summary>
    public class SpawnPlayer : IEcsInitSystem
    {
        private EcsWorld _world = null;
        private StaticData _sceneData;

        public void Init()
        {
            // Start
            // Construct prefab and spawn it
            _world.NewEntity().Get<SpawnPrefab>() = new SpawnPrefab
            {
                Prefab = _sceneData.PlayerPrefab,
                Position = Vector3.zero,
                Rotation = Quaternion.identity,
                Parent = null
            };

        }
    }

}
