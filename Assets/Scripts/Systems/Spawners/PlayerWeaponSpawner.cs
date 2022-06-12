using UnityEngine;
using Leopotam.Ecs;
using Components.Objects.Tags;
using Components.Common.MonoLinks;
using Components.Common;

namespace Systems.Spawners
{
    public class PlayerWeaponSpawner : IEcsRunSystem
    {
        private EcsWorld _world = null;
        private EcsFilter<CreateWeaponEvent> _eventFilter = null;
        private EcsFilter<PlayerTag> _playerFilter = null;
        public void Run()
        {
            if (_playerFilter.IsEmpty() || _eventFilter.IsEmpty())
            {
                return;
            }

            foreach (int index0 in _eventFilter)
            {
                GameObject prefab = _eventFilter.Get1(index0).Value;

                foreach (int index in _playerFilter)
                {
                    ref EcsEntity entity = ref _playerFilter.GetEntity(index);
                    ref GameObject gameObject = ref entity.Get<GameObjectLink>().Value;

                    _world.NewEntity().Get<SpawnPrefab>() = new SpawnPrefab
                    {
                        Prefab = prefab,
                        Position = Vector3.zero,
                        Rotation = Quaternion.identity,
                        Parent = gameObject.transform
                    };
                }

                ref EcsEntity eventEntity = ref _eventFilter.GetEntity(index0);
                eventEntity.Del<CreateWeaponEvent>();
            }
        }
    }
}
