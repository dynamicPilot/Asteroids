using Components.Objects.Weapons;
using Leopotam.Ecs;
using UnityComponents.MonoLinks.Base;


namespace UnityComponents.MonoLinks.WeaponLinks
{
    public class RecoveryTimerMonoLink : MonoLink<RecoveryTimer>
    {
        public override void Make(ref EcsEntity entity)
        {
            entity.Get<RecoveryTimer>() = new RecoveryTimer() { IsActive = false, Value = 0f, RecoveryValue = 0f };
        }
    }
}
