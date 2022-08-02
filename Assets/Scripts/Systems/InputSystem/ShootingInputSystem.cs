using Components.Common.Input;
using Components.Objects.Tags;
using Leopotam.Ecs;
using UnityComponents.Common;
using UnityEngine;


namespace System.InputSystems
{
    public class ShootingInputSystem : IEcsRunSystem
    {
        private InputControl _inputs;
        private EcsWorld _world = null;
        private EcsFilter<PlayerTag, WeaponHolderLink> _filter = null;

        public void Run()
        {
            bool fire1 = _inputs.GetFire(); // Input.GetButtonDown("BulletFire");

            if (fire1)
            {
                foreach (int index in _filter)
                {
                    ref EcsEntity entity = ref _filter.GetEntity(index);                   
                    entity.Get<FirstWeaponFireKeyDownTag>();
                }
            }

        }
    }
}
