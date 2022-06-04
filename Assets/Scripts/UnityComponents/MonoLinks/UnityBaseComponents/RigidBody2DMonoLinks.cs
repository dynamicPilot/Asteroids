using UnityEngine;
using UnityComponents.MonoLinks.Base;
using Components.Common.MonoLinks;
using Leopotam.Ecs;

namespace UnityComponents.MonoLinks.UnityBaseComponents
{
    public class RigidBody2DMonoLinks: MonoLink<Rigidbody2DLink>
    {
        // reference to Unity Rigidbody2D
        public override void Make(ref EcsEntity entity)
        {
            entity.Get<Rigidbody2DLink>() = new Rigidbody2DLink {
                Value = GetComponent<Rigidbody2D>() 
            };
        }

    }
}

