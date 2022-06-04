using System;
using Components.PhysicsEvents;
using Leopotam.Ecs;
using UnityComponents.MonoLinks.Base;
using UnityEngine;

namespace UnityComponents.MonoLinks.PhysicsLinks
{
	public class OnTriggerExit2DMonoLink : PhysicsLinkBase
	{
		private void OnTriggerExit2D(Collider2D other)
		{
			_entity.Get<OnTriggerExit2DEvent>() = new OnTriggerExit2DEvent()
			{
				Collider = other,
				Sender = gameObject
			};
		}
	}
}
