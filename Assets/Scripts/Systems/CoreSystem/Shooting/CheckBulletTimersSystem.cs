using Components.Objects.Tags;
using Components.Objects.Weapons;
using Leopotam.Ecs;

namespace Systems.CoreSystems.Shooting
{
    public class CheckBulletTimersSystem : IEcsRunSystem
    {
        private EcsFilter<RecoveryTimer, BulletTag> _filter = null;

        public void Run()
        {
            foreach (int index in _filter)
            {
                ref EcsEntity entity = ref _filter.GetEntity(index);
                ref RecoveryTimer timer = ref entity.Get<RecoveryTimer>();

                if (timer.Value <= 0)
                {
                    entity.Get<DestroyObject>() = new DestroyObject();
                }

                timer.IsActive = (timer.Value > 0);
            }

        }
    }
}
