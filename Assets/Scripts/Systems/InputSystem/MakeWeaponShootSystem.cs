
using Components.Common.Input;
using Components.Objects.Tags;
using Leopotam.Ecs;

using UnityEngine;

namespace Systems.InputSystems
{
    public class MakeWeaponShootSystem : IEcsRunSystem
    {
        //private StaticData _staticData;
        private EcsFilter<FirstWeaponFireKeyDownTag, WeaponHolderTag> _filter = null;
        private EcsFilter<WeaponTag> _weaponFilter = null;
        public void Run()
        {

            if (_weaponFilter.IsEmpty()) return;

            if (_filter.IsEmpty()) return;


            foreach (int index in _weaponFilter)
            {
                ref WeaponTag tag = ref _weaponFilter.Get1(index);
                Debug.Log("Weapon tag " + tag.Value);
                if (tag.Value == 1)
                {
                    Debug.Log("Shooting with the first weapon");
                    ref EcsEntity entity = ref _weaponFilter.GetEntity(index);
                    //entity.Get<MakeShootWithWeapon>();
                }
            }

            foreach (int index in _filter)
            {
                ref EcsEntity entity = ref _filter.GetEntity(index);
                entity.Del<FirstWeaponFireKeyDownTag>();
            }

            // suitable only for sigle player mode with two weapons !


        }

    }
}
