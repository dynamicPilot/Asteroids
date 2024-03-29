using Components.Common.MonoLinks;
using Components.Objects;
using Components.Objects.Moves;
using Leopotam.Ecs;
using UnityComponents.MonoLinks;
using UnityEngine;

namespace Systems.MoveSystems
{
    public class UpdateBodyPositionAndRotation : IEcsRunSystem
    {
        private EcsFilter<GameObjectLink, BodyLink, Position, Rotation> _filter = null;

        public void Run()
        {
            if (_filter.IsEmpty())
            {
                return;
            }

            foreach (int index in _filter)
            {
                ref GameObjectLink gameObject = ref _filter.Get1(index);
                var newPosition = _filter.Get3(index);
                ref Rotation rotation = ref _filter.Get4(index);

                if (gameObject.Value != null)
                {
                    gameObject.Value.transform.position = newPosition.Value;
                    gameObject.Value.transform.Rotate(rotation.Value);

                    rotation.AbsoluteValue = gameObject.Value.transform.eulerAngles;
                    var playerTag = gameObject.Value.GetComponent<PlayerTagMonoLink>();
                    if (playerTag != null) rotation.Value = Vector3.zero;
                }              
            }
        }
    }
}
