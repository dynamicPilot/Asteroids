using Components.Common.Input;
using Components.Common.MonoLinks;
using Components.Objects.Moves;
using Leopotam.Ecs;
using UnityComponents.Common;
using UnityEngine;

namespace Systems.MoveSystems
{
	public class UpdateAccelerationSystem : IEcsRunSystem
	{
		private StaticData _staticData;
		private EcsFilter<Velocity, Force> _filter = null;

		public void Run()
		{
			foreach (int index in _filter)
			{
				ref EcsEntity entity = ref _filter.GetEntity(index);

				ref Velocity velocity = ref entity.Get<Velocity>();
                ref GameObjectLink gameObject = ref entity.Get<GameObjectLink>();
                ref BodyLink body = ref entity.Get<BodyLink>();
                ref Force force = ref entity.Get<Force>();

                if (body.Mass <= 0) body.Mass = 0.01f;

                velocity.Acceleration = (force.Value + (-1) * velocity.Value.normalized * velocity.Value.magnitude * velocity.Value.magnitude * body.DragCoef) / body.Mass;
				force.Value = Vector3.zero;

			}
		}
	}
}