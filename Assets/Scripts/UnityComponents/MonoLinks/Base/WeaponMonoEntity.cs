using Components.Objects.Tags;
using Components.Objects.Weapons;
using Leopotam.Ecs;

namespace UnityComponents.MonoLinks.Base
{
    public class WeaponMonoEntity : MonoEntity
    {
        public override void Make(ref EcsEntity entity)
        {
            base.Make(ref entity);

            WeaponTag weaponTag = entity.Get<WeaponTag>();
            entity.Get<Shoots>() = new Shoots() { Value = weaponTag.Data.MaxShooting };
            entity.Get<RecoveryTimer>() = new RecoveryTimer() { IsActive = true, Value = 0f, RecoveryValue = weaponTag.Data.RecoveryTime };
        }
    }
}
