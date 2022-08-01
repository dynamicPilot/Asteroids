using Components.Core;

namespace Systems.CoreSystems.Shooting
{
    public class MakeShootStrategy
    {
        private IMakeShootStrategy _strategy;
        public MakeShootStrategy()
        {
        }

        public MakeShootStrategy(IMakeShootStrategy strategy)
        {
            _strategy = strategy;
        }

        public void SetShootingStrategy(IMakeShootStrategy strategy)
        {
            _strategy = strategy;
        }

        public void DoMakeShoot(MakeShoot data)
        {
            _strategy.DoShooting(data);
        }
    }

    public interface IMakeShootStrategy
    {
        void DoShooting(MakeShoot data);
    }
}
