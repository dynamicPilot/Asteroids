using Leopotam.Ecs;
using UnityEngine;

namespace UnityComponents.MonoLinks.Base
{
    //[RequireComponent(typeof(MonoEntity))]
    public abstract class MonoLinkBase : MonoBehaviour
    {
        // base class for MonoLinks with Make method
        public abstract void Make(ref EcsEntity entity);
    }
}
