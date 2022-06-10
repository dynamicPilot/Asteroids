using Components.Common.MonoLinks;
using Leopotam.Ecs;
using UnityComponents.MonoLinks.Base;
using UnityEngine;


namespace UnityComponents.MonoLinks.UnityBaseComponents
{
    /// <summary>
    /// On gameObject. Reference to BoxCollider2D Component.
    /// </summary>
    public class BoxCollider2DMonoLink : MonoLink<BoxCollider2DLink>
    {
        // reference to Unity BoxCollider2D component
        public override void Make(ref EcsEntity entity)
        {
            entity.Get<BoxCollider2DLink>() = new BoxCollider2DLink { Value = GetComponent<BoxCollider2D>() };
        }

    }
}
