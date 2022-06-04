using Leopotam.Ecs;
using UnityEngine;

namespace UnityComponents.MonoLinks.Base
{
    public class MonoLink<T> : MonoLinkBase where T : struct
    {
        // connection between Unity MonoB and ECS -> holder for ECS instance
        public T Value;

        public override void Make(ref EcsEntity entity)
        {
            if (entity.Has<T>())
            {
                Debug.Log("No component");
                return;
            }

            entity.Get<T>() = Value;
        }
    }
}

 