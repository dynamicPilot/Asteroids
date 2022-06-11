using Components.Common;
using Components.Common.MonoLinks;
using Components.Objects.Moves;
using Components.Objects.Tags;
using Leopotam.Ecs;
using UnityComponents.Common;
using UnityEngine;

namespace Systems.MoveSystems
{
    public class FollowPlayerAddForceSystem : IEcsRunSystem
    {
		private StaticData _staticData;
		private EcsFilter<FollowPlayerTag, Force> _filter = null;
		private EcsFilter<PlayerPositionShearer> _shearerFilter = null;
		public void Run()
		{
			if (_shearerFilter == null) return;

			int followPlayerIndex = Random.Range(0, _shearerFilter.GetEntitiesCount());
			Vector3 playerPosition = _shearerFilter.Get1(followPlayerIndex).Value;

			foreach (int index in _filter)
			{
				ref EcsEntity entity = ref _filter.GetEntity(index);

				ref GameObjectLink gameObject = ref entity.Get<GameObjectLink>();				
				ref Force force = ref entity.Get<Force>();
				Vector3 direction = playerPosition - gameObject.Value.transform.position;

				force.Value = direction * _staticData.UFOPushForce;

			}			
		}
	}
}
