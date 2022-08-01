using Components.Objects.Weapons;
using Leopotam.Ecs;

namespace UnityComponents.MonoLinks.Base
{
    public class BulletMonoEntity : MonoEntity
    {
        public override void Make(ref EcsEntity entity)
        {
            base.Make(ref entity);

            ref RecoveryTimer timer = ref entity.Get<RecoveryTimer>();
            timer.Value = timer.RecoveryValue;
            timer.IsActive = true;
        }

        public void DestroyMe()
        {
            _entity.Get<DestroyObject>() = new DestroyObject();
        }
    }
}
