using Leopotam.Ecs;

namespace UnityComponents.MonoLinks.Base
{
	/// <summary>
	/// Base class for Physics Objects.
	/// </summary>
	public abstract class PhysicsLinkBase : MonoLinkBase
	{
		protected EcsEntity _entity;
		public override void Make(ref EcsEntity entity)
		{
			_entity = entity;
		}
    }
}
