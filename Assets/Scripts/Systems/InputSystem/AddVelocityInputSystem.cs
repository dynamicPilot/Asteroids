using Components.Common.Input;
using Components.Objects.Moves;
using Leopotam.Ecs;
using UnityComponents.Common;
using UnityEngine;

namespace Systems.InputSystems
{
	public class AddVelocityInputSystem : IEcsRunSystem
	{
		private StaticData _staticData;
		private EcsFilter<VertucalKeyDownTag> _filter = null;

		public void Run()
		{
			foreach (int index in _filter)
			{
				Debug.Log("Add velocity");
				ref EcsEntity entity = ref _filter.GetEntity(index);
				ref Velocity velocity = ref entity.Get<Velocity>();
				velocity.Value += _staticData.PlayerAddForce;
			}
		}
	}
}