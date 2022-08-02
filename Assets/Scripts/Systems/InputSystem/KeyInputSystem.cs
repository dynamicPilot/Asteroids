using Components.Common.Input;
using Components.Objects.Tags;
using Leopotam.Ecs;
using UnityComponents.Common;
using UnityEngine;


namespace System.InputSystems
{
    public class KeyInputSystem : IEcsRunSystem
    {
        private InputControl _inputs;
        //private EcsWorld _world = null;
        private EcsFilter<PlayerTag> _filter = null;

        public void Run()
        {
            if (_inputs == null) return;

            float v = _inputs.GetVerticalAxis(); //Input.GetAxis("Vertical");
            float h = _inputs.GetHorizontalAxis(); //Input.GetAxis("Horizontal");

            if (v > 0)
            {
                foreach (int index in _filter)
                {
                    ref EcsEntity entity = ref _filter.GetEntity(index);
                    entity.Get<VertucalKeyDownTag>();
                }
            }

            if (h < 0) h = 1f;
            else if (h > 0) h = -1f;
            else return;

            foreach (int index in _filter)
            {
                ref EcsEntity entity = ref _filter.GetEntity(index);
                entity.Get<HorizontalKeyDownTag>().Value = h;
            }



            //if (Input.anyKeyDown)
            //{
            //    _world.NewEntity().Get<AnyKeyDownTag>(); 
            //}
        }
    }
}

