using Components.Core;
using Components.Objects.Tags;
using Components.Objects.Weapons;
using Leopotam.Ecs;
using Systems.CoreSystems.Shooting;

namespace UnityComponents.MonoLinks.Base
{
    public class WeaponMonoEntity : MonoEntity, IMakeShootStrategy
    {
        private protected Shoots _shoots;
        private protected RecoveryTimer _recoveryTimer;

        public void DoShooting(MakeShoot data)
        {
            if (WeaponCanShoot()) MakeShootMethod(data);
            else return;
        }

        protected virtual void MakeShootMethod(MakeShoot data)
        {
            _entity.Get<MakeShoot>() = data;
        }

        public override void Make(ref EcsEntity entity)
        {
            base.Make(ref entity);

            WeaponTag weaponTag = entity.Get<WeaponTag>();
            entity.Get<Shoots>() = new Shoots() { Value = weaponTag.Data.MaxShoots, MaxValue = weaponTag.Data.MaxShoots };
            entity.Get<RecoveryTimer>() = new RecoveryTimer() { 
                IsActive = false, 
                Value = 0f, 
                RecoveryValue = weaponTag.Data.RecoveryTime 
            };

            _shoots = entity.Get<Shoots>();
            _recoveryTimer = entity.Get<RecoveryTimer>();
        }

        protected bool WeaponCanShoot()
        {
            return !(_shoots.Value < 1 || _recoveryTimer.IsActive);
        }
    }
}
