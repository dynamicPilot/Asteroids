using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityComponents.Common
{
    [CreateAssetMenu(menuName = "Weapon/WeaponData", fileName = "WeaponData", order = 0)]
    public class WeaponData : ScriptableObject
    {
        public string WeaponName;
        public int MaxShooting;
        public float RecoveryTime = 1f;
        public GameObject BulletPrefab;
    }
}

