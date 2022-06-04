using UnityEngine;

namespace Components.PhysicsEvents
{
	public struct OnCollisionEnter2DEvent
	{
		public GameObject Sender;
		public Collision2D Collision;
	}
}