using System.Collections;
using UnityEngine;

/// <summary>
/// Class <c>EnemySpawnerTimerAndCreator</c> creates GameObjects for Enemies and serves as a timer
/// </summary>
/// 
public class EnemySpawnerTimerAndCreator : MonoBehaviour
{ 
    [Header("Parameters")]
    [SerializeField] private float minTimerValue = 2f;
    [SerializeField] private float maxTimerValue = 5f;
    
    [Header("Components")]
    [SerializeField] private EnemyGameObjectCreator asteroidGameObjectCreator;
    [SerializeField] private EnemyGameObjectCreator ufoGameObjectCreator;

    [Header("EnemyCreator class overview")]
    [SerializeField] private EnemyCreator enemyCreator;
    private WaitForSeconds timer;
    
    public void SetEnemySpawner(EnemyCreator _enemyCreator)
    {
        enemyCreator = _enemyCreator;

        if (enemyCreator == null)
        {
            Debug.LogError("EnemySpawnerTimerAndParams: no enemyCreator!");
        }
    }

    public void StartEnemyCreator()
    {
        StartCoroutine(Spawner());
    }

    IEnumerator Spawner()
    {
        enemyCreator.CreateEnemy();
        timer = new WaitForSeconds(Random.Range(minTimerValue, maxTimerValue));
        yield return timer;
        StartCoroutine(Spawner());
    }

    public Transform CreateEnemyAndGetTransform(Vector3 position, Quaternion rotation, EnemyCreator.TYPE type, bool isSmall = false)
    {
        if (type == EnemyCreator.TYPE.asteroid)
        {
            return asteroidGameObjectCreator.CreateEnemy(position, Quaternion.Euler(0f, 0f, Random.Range(-0.0f, 359.0f)), isSmall);
        }
        else
        {
            return ufoGameObjectCreator.CreateEnemy(position, Quaternion.Euler(0f, 0f, 0f));
        }
    }

}
