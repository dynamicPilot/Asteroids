using Components.Common.Input;
using Components.Common.MonoLinks;
using Components.Objects.Moves;
using Leopotam.Ecs;
using UnityComponents.Common;
using UnityEngine;

namespace Systems.InputSystems
{
    public class AddRotationInputSystem : IEcsRunSystem
    {
        //private StaticData _staticData;
        private EcsFilter<HorizontalKeyDownTag> _filter = null;

        public void Run()
        {
            if (_filter == null)
            {
                return;
            }

            foreach (int index in _filter)
            {
                Debug.Log("Add rotation");
                ref EcsEntity entity = ref _filter.GetEntity(index);
                float direction = _filter.Get1(index).Value;
                ref Rotation rotation = ref entity.Get<Rotation>();
                ref BodyLink bodyLink = ref entity.Get<BodyLink>();

                rotation.Value = new Vector3(0f, 0f, bodyLink.AngularVelocity * direction);

                entity.Del<HorizontalKeyDownTag>();
            }
        }
    }
}
