using UnityEngine;

/// <summary>
/// Class <c>GameObjectCreator</c> creates GameObjects by prefab
/// </summary>
/// 
public class GameObjectCreator : MonoBehaviour
{
    [Header("Prefab")]
    [SerializeField] private GameObject prefab;

    public Transform CreateGameObject(Vector3 position, Quaternion rotation, Transform parentTransform = null)
    {
        if (parentTransform == null)
        {
            parentTransform = transform;
        }
        return Instantiate(prefab, position, rotation, parentTransform).GetComponent<Transform>();
    }
}
