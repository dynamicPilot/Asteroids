using UnityEngine;

namespace UnityComponents.Common
{
    [CreateAssetMenu(menuName = "Config/StaticData", fileName = "StaticData", order = 0)]
    public class StaticData : ScriptableObject
    {
        public GameObject PlayerPrefab;
        public GameObject AsteroidPrefab;

        [Header("Enemies")]
        public float SpawnTimer = 5f;

        [Header("Physics")]
        public Vector3 PlayerAddForce = new Vector3(0f, 0.001f, 0f);
        [SerializeField] private Vector3 _globalGravitation = new Vector3(0f, -0.0009f, 0f);
        public Vector3 GlobalGravitation { get => _globalGravitation; }

        [Header("Teleport Screen")]
        public GameObject TeleportPrefab;
    }
}

