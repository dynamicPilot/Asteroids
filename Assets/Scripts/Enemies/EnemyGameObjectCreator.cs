using UnityEngine;

public class EnemyGameObjectCreator : GameObjectCreator
{
    [Header("Sprites")]
    [SerializeField] private Sprite[] sprites;

    public Transform CreateEnemy (Vector3 position, Quaternion rotation, bool isSmall = false)
    {
        // create new object
        Transform newEnemy = CreateGameObject(position, rotation);

        // set sprite
        newEnemy.GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length)];

        if (isSmall)
        {
            // change scale 
            newEnemy.localScale = new Vector3(newEnemy.localScale.x / 2, newEnemy.localScale.y / 2, newEnemy.localScale.z / 2);
        }

        return newEnemy;
    }
}

