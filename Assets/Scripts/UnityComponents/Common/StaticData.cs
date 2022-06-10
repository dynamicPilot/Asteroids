using UnityEngine;

namespace UnityComponents.Common
{
    [CreateAssetMenu(menuName = "Config/StaticData", fileName = "StaticData", order = 0)]
    public class StaticData : ScriptableObject
    {
        [Header("Player")]
        public GameObject PlayerPrefab;
        public float PlayerAngularVelocity = 3f;

        [Header("Enemies")]
        public GameObject AsteroidPrefab;
        public int MaxEnemiesNumber = 15;
        public float SpawnTimer = 10f;
        [Header("---")]
        public float SpawnerRectX = 10f;
        public float SpawnerRectY = 6f;
        [Header("---")]
        public float SpawnerMinRotation = -0.5f;
        public float SpawnerMaxRotation= 0.5f;
        [Header("---")]
        public float SpawnerMinVelocity = -1.5f;
        public float SpawnerMaxVelocity = 1.5f;

        [Header("Physics")]
        [SerializeField] private float _pushForce = 100f;
        public float PushForce { get => _pushForce; }

        [SerializeField] private float _velocitySensitivity = 0.01f;
        public float VelocitySensitivity { get => _velocitySensitivity; }

        [SerializeField] private Vector3 _globalGravitation = new Vector3(0f, -0.0009f, 0f);
        public Vector3 GlobalGravitation { get => _globalGravitation; }

        [Header("Teleport Screen")]
        public GameObject TeleportPrefab;
        public GameObject ExternalTeleportPrefab;
    }
}

