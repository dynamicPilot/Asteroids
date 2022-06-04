using Components.Objects;
using Components.Objects.Moves;
using Leopotam.Ecs;


namespace Systems.MoveSystems
{
    public class MoveSystem : IEcsRunSystem
    {
        private EcsFilter<Velocity> _filter = null;

        public void Run()
        {
            // update or fixed update
            foreach (int index in _filter)
            {
                ref EcsEntity entity = ref _filter.GetEntity(index); // get entity from filter
                ref Position position = ref entity.Get<Position>(); // get position from entity
                Velocity velocity = _filter.Get1(index);

                position.Value += velocity.Value;
            }

        }
    }
}

