using Components.Common.MonoLinks;
using Leopotam.Ecs;
using UnityComponents.MonoLinks.Base;
using UnityEngine;

namespace UnityComponents.MonoLinks.UnityBaseComponents
{
    public class GameObjectMonoLink : MonoLink<GameObjectLink>
    {
        // reference to Unity GameObject
        public override void Make(ref EcsEntity entity)
        {
            entity.Get<GameObjectLink>() = new GameObjectLink { Value = gameObject };
        }
    }
}

