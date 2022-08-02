using Components.Objects.Moves;
using Leopotam.Ecs;
using UnityComponents.Common;
using UnityEngine;
using Utilities.Spawner;

namespace UnityComponents.MonoLinks.Base
{
    public class AsteroidMonoEntity : MonoEntity
    {
        [SerializeField] private StaticData _staticData;
        public override void Make(ref EcsEntity entity)
        {
            base.Make(ref entity);

            entity.Get<Rotation>() = new Rotation { Value = SpawnerUtility.GetRotationToSpawn(_staticData), AbsoluteValue = SpawnerUtility.GetRotationToSpawn(_staticData) };
        }

    }
}
