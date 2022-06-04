using System;
using Components.PhysicsEvents;
using Leopotam.Ecs;
using UnityComponents.MonoLinks.Base;
using UnityEngine;

namespace UnityComponents.MonoLinks.PhysicsLinks
{
	public class OnTriggerEnter2DMonoLink : PhysicsLinkBase
	{
		private void OnTriggerEnter2D(Collider2D other)
		{
			_entity.Get<OnTriggerEnter2DEvent>() = new OnTriggerEnter2DEvent()
			{
				Collider = other,
				Sender = gameObject
			};
		}
	}
}