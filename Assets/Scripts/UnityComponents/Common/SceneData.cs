using UnityEngine;
using UnityComponents.Factories;

namespace UnityComponents.Common
{
    public class SceneData : MonoBehaviour
    {
        [SerializeField] private PrefabFactory _factory;
        public PrefabFactory Factory { get => _factory; }

        [SerializeField] private DestroyFactory _destroyer;
        public DestroyFactory Destroyer { get => _destroyer; }

        public Transform AsteroidsContainer;
        public Transform UFOsContainer;
        public Transform TeleportContainer;
        public Transform BulletsContainer;
    }
}

