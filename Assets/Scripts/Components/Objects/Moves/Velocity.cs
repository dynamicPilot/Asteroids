using UnityEngine;

namespace Components.Objects.Moves
{
    /// <summary>
    /// Hold Vector3 Velocity value.
    /// </summary>
    [System.Serializable]
    public struct Velocity
    {
        public Vector3 Value;
        public Vector3 Acceleration;
    }
}

