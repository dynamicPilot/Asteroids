using Components.Common.Input;
using Components.Objects.Tags;
using Leopotam.Ecs;
using UnityEngine;


namespace System.InputSystems
{
    public class ShootingInputSystem : IEcsRunSystem
    {
        private EcsWorld _world = null;
        private EcsFilter<PlayerTag, WeaponHolderTag> _filter = null;

        public void Run()
        {
            bool fire1 = Input.GetButtonDown("BulletFire");
            bool fire2 = Input.GetButtonDown("LaserFire");

            if (fire1)
            {
                foreach (int index in _filter)
                {
                    Debug.Log("fire 1");
                    ref EcsEntity entity = ref _filter.GetEntity(index);                   
                    entity.Get<FirstWeaponFireKeyDownTag>();
                }
            }

        }
    }
}
