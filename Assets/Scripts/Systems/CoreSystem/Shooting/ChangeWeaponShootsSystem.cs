using Components.Core;
using Components.Objects.Weapons;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems.CoreSystems.Shooting
{
    public class ChangeWeaponShootsSystem : IEcsRunSystem
    {
        private EcsFilter<Shoots, RecoveryTimer, MakeShoot> _filter = null;

        public void Run()
        {
            foreach(int index in _filter)
            {
                ref EcsEntity entity = ref _filter.GetEntity(index);
                ref Shoots shoots = ref entity.Get<Shoots>();
                shoots.Value -= 1;

                ref RecoveryTimer timer = ref entity.Get<RecoveryTimer>();
                timer.Value += timer.RecoveryValue;
                timer.IsActive = true;
                //entity.Del<MakeShoot>();
            }
        }
    }
}
