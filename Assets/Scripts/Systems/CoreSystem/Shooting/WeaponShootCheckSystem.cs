using Components.Common.Input;
using Components.Common.MonoLinks;
using Components.Core;
using Components.Objects.Tags;
using Components.Objects.Weapons;
using Leopotam.Ecs;

using UnityEngine;

namespace Systems.CoreSystems.Shooting
{
    public class WeaponShootCheckSystem : IEcsRunSystem
    {
        //private StaticData _staticData;
        private EcsFilter<FirstWeaponFireKeyDownTag, WeaponHolderTag> _filter = null;
        private EcsFilter<WeaponTag> _weaponFilter = null;
        public void Run()
        {

            if (_weaponFilter.IsEmpty()) return;

            if (_filter.IsEmpty()) return;

            foreach (int index0 in _filter)
            {
                Debug.Log("Check for holder.....");
                ref EcsEntity holderEntity = ref _filter.GetEntity(index0);
                ref GameObject holderObject = ref holderEntity.Get<GameObjectLink>().Value;

                foreach (int index1 in _weaponFilter)
                {
                    ref WeaponTag tag = ref _weaponFilter.Get1(index1);

                    if (tag.Value == 0)
                    {
                        ref EcsEntity weaponEntity = ref _weaponFilter.GetEntity(index1);
                        Debug.Log("Check for shoot.....");
                        if (WeaponCanShoot(weaponEntity))
                        {
                            Debug.Log("MakeShoot!");
                            weaponEntity.Get<MakeShoot>() = new MakeShoot()
                            {
                                PlayerContainer = holderObject.transform,
                                Velocity = holderObject.transform.up
                            };
                        }
                    }
                }

                holderEntity.Del<FirstWeaponFireKeyDownTag>();
            }

        }

        bool WeaponCanShoot(EcsEntity entity)
        {
            ref Shoots shoots = ref entity.Get<Shoots>();
            ref RecoveryTimer timer = ref entity.Get<RecoveryTimer>();

            Debug.Log("Shoots value " + shoots.Value);
            Debug.Log("Recovery timer " + timer.IsActive);
            return !(shoots.Value < 1 || timer.IsActive);
        }

    }
}
