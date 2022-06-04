using Components.PhysicsEvents;
using Leopotam.Ecs;
using UnityComponents.MonoLinks.Base;
using UnityEngine;

namespace UnityComponents.MonoLinks.PhysicsLinks
{
	public class OnCollisionEnter2DMonoLink : PhysicsLinkBase
	{
		public void OnCollisionEnter2D(Collision2D other)
		{
			_entity.Get<OnCollisionEnter2DEvent>() = new OnCollisionEnter2DEvent
			{
				Collision = other,
				Sender = gameObject
			};
		}
	}
}