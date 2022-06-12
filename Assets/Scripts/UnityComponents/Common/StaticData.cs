using UnityEngine;

namespace UnityComponents.Common
{
    [CreateAssetMenu(menuName = "Config/StaticData", fileName = "StaticData", order = 0)]
    public class StaticData : ScriptableObject
    {
        [Header("Player")]
        public GameObject PlayerPrefab;
        [Header("---")]
        public GameObject PistolPrefab;
        [Header("---")]
        public float PushForce = 100f;
        public float PlayerAngularVelocity = 3f;

        [Header("Enemies")]
        public GameObject AsteroidPrefab;
        public GameObject UFOPrefab;
        public float UFOPart = 0.3f;
        [Header("---")]
        public float UFOPushForce = 60f;
        [Header("---")]
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
        public float VelocitySensitivity = 0.01f;
        public Vector3 GlobalGravitation = new Vector3(0f, 0f, 0f);

        [Header("Teleport Screen")]
        public GameObject TeleportPrefab;
        public GameObject ExternalTeleportPrefab;
    }
}

