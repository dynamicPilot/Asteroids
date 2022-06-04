using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityComponents.MonoLinks.Base;
using UnityEngine;

namespace UnityComponents.Factories
{
    public class PrefabFactory : MonoBehaviour
    {
        // Factory for spawn enemies
        // Assests ECS Systems to spawn game objects
        private EcsWorld _world;

        public void SetWorld(EcsWorld world)
        {
            _world = world;
        }

        public void SpawnPrefab(SpawnPrefab prefab)
        {
            GameObject gameObject = Instantiate(prefab.Prefab, prefab.Position, prefab.Rotation, prefab.Parent);
            var monoEntity = gameObject.GetComponent<MonoEntity>();

            if (monoEntity == null) return;

            EcsEntity ecsEntity = _world.NewEntity();
            monoEntity.Make(ref ecsEntity);
        }
    }
}


