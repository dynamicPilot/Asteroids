
using Leopotam.Ecs;

public enum SIDE { up, down, right, left}
namespace Components.Objects.Tags
{
    /// <summary>
    /// Contains side to teleport
    /// </summary>
    public struct TeleportingTag
    {
        public SIDE Value;
    }
}
