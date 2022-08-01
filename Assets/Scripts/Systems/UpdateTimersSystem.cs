using Components.Objects.Weapons;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems
{
    public class UpdateTimersSystem : IEcsRunSystem
    {
        private EcsFilter<RecoveryTimer> _filter = null;

        public void Run()
        {
            foreach (int index in _filter)
            {
                ref EcsEntity entity = ref _filter.GetEntity(index);
                ref RecoveryTimer timer = ref entity.Get<RecoveryTimer>();

                if (timer.IsActive)
                {
                    timer.Value -= Time.deltaTime;
                }
                
            }

        }
    }
}
