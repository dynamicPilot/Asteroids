using Components.Objects.Weapons;
using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Systems.CoreSystems
{
    public class DestroyByTimerSystem : IEcsRunSystem
    {
        //private EcsFilter<RecoveryTimer> _filter = null;

        public void Run()
        {
            //foreach (int index in _filter)
            //{
            //    ref EcsEntity entity = ref _filter.GetEntity(index);
            //    ref RecoveryTimer timer = ref entity.Get<RecoveryTimer>();
            //    timer.Value -= Time.deltaTime;
            //}
        }
    }
}

