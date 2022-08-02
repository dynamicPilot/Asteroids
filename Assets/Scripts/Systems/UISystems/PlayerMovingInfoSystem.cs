using Components.Objects;
using Components.Objects.Moves;
using Components.Objects.Tags;
using Leopotam.Ecs;
using UnityComponents.Common;

namespace Systems.MoveSystems
{
    public class PlayerMovingInfoSystem : IEcsRunSystem
    {
		private SceneData _sceneData;
		private EcsWorld _world = null;
		private EcsFilter<PlayerTag, Position, Rotation, Velocity> _filter = null;
		public void Run()
		{
			if (_filter.IsEmpty())
				return;

			foreach (int index in _filter)
			{
				ref Position position = ref _filter.Get2(index);
				ref Rotation rotation = ref _filter.Get3(index);
				ref Velocity velocity = ref _filter.Get4(index);

				_sceneData.GameUIScript.SetPosition(position.Value);

				float temp = rotation.AbsoluteValue.z;
				if (temp > 180) temp = 360 - temp;

				_sceneData.GameUIScript.SetRotation(temp);

				_sceneData.GameUIScript.SetVelocity(velocity.Value.magnitude);
			}
		}
	}
}
