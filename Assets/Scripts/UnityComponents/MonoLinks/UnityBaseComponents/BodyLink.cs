using UnityEngine;

namespace Components.Common.MonoLinks
{
    /// <summary>
    /// Link. Movable objects
    /// </summary>
    [System.Serializable]
    public struct BodyLink
    {
        [SerializeField] private float _mass;
        public float Mass { get => _mass; set => _mass = value; }

        [SerializeField] private float _dragCoef;
        public float DragCoef { get => _dragCoef; }

        [SerializeField] private float _angularVelocity;
        public float AngularVelocity { get => _angularVelocity; }
    }
}
