using Components.Common.Input;
using Components.Objects.Tags;
using Leopotam.Ecs;
using UnityEngine;


namespace System.InputSystems
{
    public class KeyInputSystem : IEcsRunSystem
    {
        private EcsWorld _world = null;
        private EcsFilter<PlayerTag> _filter = null;

        public void Run()
        {
            float v = Input.GetAxis("Vertical");

            if (v == 0 || v < 0)
            {
                return;
            }

            foreach (int index in _filter)
            {
                ref EcsEntity entity = ref _filter.GetEntity(index);
                entity.Get<VertucalKeyDownTag>();
            }

            //if (Input.anyKeyDown)
            //{
            //    _world.NewEntity().Get<AnyKeyDownTag>(); 
            //}
        }
    }
}

