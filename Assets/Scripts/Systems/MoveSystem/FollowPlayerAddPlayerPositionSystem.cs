using Components.Common;
using Components.Common.MonoLinks;
using Components.Objects;
using Components.Objects.Tags;
using Leopotam.Ecs;


namespace Systems.MoveSystems
{
    public class FollowPlayerAddPlayerPositionSystem : IEcsRunSystem
    {
		private EcsWorld _world = null;
		private EcsFilter<PlayerTag, Position> _filter = null;

		public void Run()
		{
			if (_filter == null)
            {
				return;
			}
			foreach (int index in _filter)
            {
				ref EcsEntity entity = ref _filter.GetEntity(index);
				Position position = _filter.Get2(index);
				entity.Get<PlayerPositionShearer>().Value = position.Value;
			}
			
		}
	}
}
