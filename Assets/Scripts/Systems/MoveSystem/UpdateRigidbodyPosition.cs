using Components.Common.MonoLinks;
using Components.Objects;
using Leopotam.Ecs;


namespace Systems.MoveSystems
{
    public class UpdateRigidbodyPosition : IEcsRunSystem
    {
        private EcsFilter<Rigidbody2DLink, Position> _filter = null;

        public void Run()
        {
			if (_filter.IsEmpty())
			{
				return;
			}

			foreach (int index in _filter)
			{
				ref Rigidbody2DLink rigidbody2D = ref _filter.Get1(index);
				var newPosition = _filter.Get2(index);

				rigidbody2D.Value.MovePosition(newPosition.Value);
			}
		}
    }
}

