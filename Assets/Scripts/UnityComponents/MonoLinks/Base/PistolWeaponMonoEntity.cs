using Leopotam.Ecs;

namespace UnityComponents.MonoLinks.Base
{
    public class PistolWeaponMonoEntity : WeaponMonoEntity
    {
        public override void Make(ref EcsEntity entity)
        {
            base.Make(ref entity);

            GetComponentInParent<PlayerMonoEntity>().SetNewWeapon(this);
        }
    }
}
