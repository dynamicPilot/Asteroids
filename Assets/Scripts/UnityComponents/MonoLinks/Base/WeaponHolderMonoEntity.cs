using Components.Core;
using Leopotam.Ecs;
using Systems.CoreSystems.Shooting;

namespace UnityComponents.MonoLinks.Base
{
    public class WeaponHolderMonoEntity : MonoEntity
    {
        private MakeShootStrategy[] _weapon;
        public override void Make(ref EcsEntity entity)
        {
            base.Make(ref entity);

            _weapon = new MakeShootStrategy[1] { new MakeShootStrategy() };
        }

        public void DoMakeShoot(MakeShoot data, int index = 0)
        {
            _weapon[index].DoMakeShoot(data);
        }

        public void SetNewWeapon(IMakeShootStrategy weapon, int index = 0)
        {
            _weapon[index].SetShootingStrategy(weapon);
        }
    }
}
