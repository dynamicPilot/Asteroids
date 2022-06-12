using UnityEngine;
using Utilities.Spawner;

public struct SpawnPrefab
{
	public GameObject Prefab;
	public Vector3 Position;
	public Quaternion Rotation;
	public Transform Parent;
}

public struct SpawnPrefabWithVelocity
{
	public GameObject Prefab;
	public Vector3 Position;
	public Quaternion Rotation;
	public Transform Parent;
	public Vector3 Velocity;
}
