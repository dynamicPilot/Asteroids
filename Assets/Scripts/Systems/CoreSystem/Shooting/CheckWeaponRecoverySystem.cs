using Components.Core;
using Components.Objects.Weapons;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems.CoreSystems.Shooting
{
    public class CheckWeaponRecoverySystem : IEcsRunSystem
    {
        private EcsFilter<RecoveryTimer> _filter = null;

        public void Run()
        {
            foreach (int index in _filter)
            {
                ref EcsEntity entity = ref _filter.GetEntity(index);
                ref RecoveryTimer timer = ref entity.Get<RecoveryTimer>();
                timer.Value -= Time.deltaTime;


                if (timer.Value <= 0)
                {
                    ref Shoots shoots = ref entity.Get<Shoots>();

                    if (shoots.Value < shoots.MaxValue)
                        shoots.Value++;
                    else
                        timer.Value = 0;
                }

                timer.IsActive = (timer.Value > 0);
            }

        }

    }
}
