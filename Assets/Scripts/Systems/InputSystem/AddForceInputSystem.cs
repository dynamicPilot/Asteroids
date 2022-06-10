using Components.Common.Input;
using Components.Common.MonoLinks;
using Components.Objects.Moves;
using Leopotam.Ecs;
using UnityComponents.Common;

namespace Systems.InputSystems
{
    public class AddForceInputSystem : IEcsRunSystem
    {
		private StaticData _staticData;
		private EcsFilter<VertucalKeyDownTag> _filter = null;

		public void Run()
		{
			foreach (int index in _filter)
			{
				ref EcsEntity entity = ref _filter.GetEntity(index);

				//ref Velocity velocity = ref entity.Get<Velocity>();
				ref GameObjectLink gameObject = ref entity.Get<GameObjectLink>();
				ref BodyLink body = ref entity.Get<BodyLink>();
				ref Force force = ref entity.Get<Force>();

				force.Value = gameObject.Value.transform.up * _staticData.PushForce;

				entity.Del<VertucalKeyDownTag>();
			}
		}
	}
}
