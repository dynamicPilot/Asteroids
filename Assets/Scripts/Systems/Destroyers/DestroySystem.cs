using Components.Common.MonoLinks;
using Leopotam.Ecs;
using UnityComponents.Common;
using UnityComponents.Factories;
using UnityEngine;

namespace Systems.Destroyers
{
    public class DestroySystem : IEcsRunSystem, IEcsPreInitSystem
    {
        private EcsFilter<DestroyObject> _filter = null;

        private EcsWorld _world;
        private SceneData _sceneData;
        private DestroyFactory _destroyer;

        public void PreInit()
        {
            // Awake
            _destroyer = _sceneData.Destroyer;
            _destroyer.SetWorld(_world);
        }

        public void Run()
        {
            if (_filter.IsEmpty())
            {
                return;
            }

            foreach (int index in _filter)
            {
                ref EcsEntity destroyEntity = ref _filter.GetEntity(index);
                ref GameObject destroyObject = ref destroyEntity.Get<GameObjectLink>().Value;
                _destroyer.DestroyObject(destroyObject);
                destroyEntity.Destroy();
            }
        }
    }
}
