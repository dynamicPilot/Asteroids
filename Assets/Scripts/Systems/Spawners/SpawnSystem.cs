using Leopotam.Ecs;
using UnityComponents.Factories;
using UnityComponents.Common;


namespace Systems.Spawners
{
    public class SpawnSystem : IEcsPreInitSystem, IEcsRunSystem
    {
        private EcsWorld _world;
        private SceneData _sceneData;

        private EcsFilter<SpawnPrefab> _spawnFilter = null;

        private PrefabFactory _factory;

        public void PreInit()
        {
            // Awake
            _factory = _sceneData.Factory;
            _factory.SetWorld(_world);
        }

        public void Run()
        {
            if (_spawnFilter.IsEmpty())
            {
                // no enemies need to be spawn -> filter is empty
                return;
            }

            // check any element in filter
            foreach (int index in _spawnFilter)
            {
                ref EcsEntity spawnEntity = ref _spawnFilter.GetEntity(index); // get index of Entity
               
                var spawnPrefab = spawnEntity.Get<SpawnPrefab>(); // get or add component of type EnemyPrefab -> almost like GetComponent<>() Unity
                _factory.SpawnPrefab(spawnPrefab);
                spawnEntity.Del<SpawnPrefab>(); // delete component SpawnPrefab from spawnEntity ->
                                                // это позже способствует удалению самой Entity, так как не бывает пустых сущностей
            }
        }
    }
}

