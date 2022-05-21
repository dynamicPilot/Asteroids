using UnityEngine;

/// <summary>
/// Class <c>EnemyCreator</c> creates Enemies classes and control enemies number
/// Requires EnemySpawnerTimerAndCreator Component
/// </summary>
/// 

[System.Serializable]
public class EnemyCreator
{
    public enum TYPE { asteroid, ufo}

    #region("Variables")
    [Header("Enemy Spawner Points")]
    [SerializeField] private float minX = -10f;
    [SerializeField] private float minY = -6f;

    [Header("Asteroids Parameters")]
    [SerializeField] private float minAngularVelocity = 0.1f;
    [SerializeField] private float maxAngularVelocity = 1f;
    [SerializeField] private int pointsForBigAsteroid = 10;
    [SerializeField] private int pointsForSmallAsteroid = 5;

    [Header("UFOs Parameters")]
    [SerializeField] private float mass = 20f;
    [SerializeField] private float pushForce = 20f;
    [SerializeField] private float dragCoef = 10f;
    [SerializeField] private int pointsForUFO = 20;

    [Header("Enemy Spawner Parameters")]
    [SerializeField] private float asteroidsPart = 0.7f;
    [SerializeField] private int maxEnemiesNumber = 20;

    private Player player;
    private EnemySpawnerTimerAndCreator enemySpawner;

    private float[] xCoord;
    private float[] yCoord;

    private int enemiesNumber = 0;

    #endregion

    public EnemyCreator(Player _player, EnemySpawnerTimerAndCreator _enemySpawner)
    {
        player = _player;
        enemySpawner = _enemySpawner;

        // calculate all sides for rectangular-> creator will spawn new enemy on this sides
        xCoord = new float[2] { minX, -1 * minX };
        yCoord = new float[2] { minY, -1 * minY };

        enemySpawner.SetEnemySpawner(this);
    }

    public void StartEnemyCreator()
    {
        enemySpawner.StartEnemyCreator();
    }

    public void StopEnemyCreator()
    {
        enemySpawner.StopAllCoroutines();
    }

    public void CreateEnemy()
    {
        if (enemiesNumber >= maxEnemiesNumber) return;

        int type = 0;
        if (Random.Range(0f, 1f) > asteroidsPart) type = 1;

        // choose rectangular side where spawn an enemy
        int sideIndex = Random.Range(1, 5);
        Vector3 position = GetPosition(sideIndex);

        if ((TYPE) type == TYPE.asteroid)
        {
            // create big asteroid
            Vector2 velocity = GetVelocity(sideIndex);

            // choose direction of rotation for asteroid
            int rotationDirection = Mathf.FloorToInt(Mathf.Sign(Random.Range(-1f, 1f)) * 1f);

            // asteroid needs velocity vector, angular velocity, rotation direction
            // asteroid mass is default, dragCoef is 0, pushForce is 0
            new Asteroid(enemySpawner.CreateEnemyAndGetTransform(position, Quaternion.Euler(0f, 0f, Random.Range(-0.0f, 359.0f)), (TYPE)type), 
                player, velocity, Random.Range(minAngularVelocity, maxAngularVelocity), rotationDirection, pointsForBigAsteroid, this);
        }
        else if ((TYPE) type == TYPE.ufo)
        {
            // create ufo
            // UFO needs mass, dragCoef, pushForce
            // UFO start velocity is zero vector, without rotation
            new UFO(enemySpawner.CreateEnemyAndGetTransform(position, Quaternion.Euler(0f, 0f, 0f), (TYPE)type), player, this, pointsForUFO,
                mass, pushForce, dragCoef);
        }

        enemiesNumber++;
    }

    public void CreateSmallEnemies(Vector2 position)
    {
        // Note: small enemies are not incuded in maxEnemiesNumber

        for (int i = Random.Range(2, 5); i > 0; i--)
        {
            // create small asteroid
            Vector2 velocity = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized * Random.Range(1.1f,2f);

            // choose direction of rotation for asteroid
            int rotationDirection = Mathf.FloorToInt(Mathf.Sign(Random.Range(-1f, 1f)) * 1f);

            // asteroid needs velocity vector, angular velocity, rotation direction
            // asteroid mass is default, dragCoef is 0, pushForce is 0
            new Asteroid(enemySpawner.CreateEnemyAndGetTransform(position, Quaternion.Euler(0f, 0f, Random.Range(-0.0f, 359.0f)), TYPE.asteroid, true),
                    player, velocity, Random.Range(minAngularVelocity * 1.5f, maxAngularVelocity * 1.5f), rotationDirection, pointsForSmallAsteroid, this, 0);
        }        
    }

    public void EnemyHasDied()
    {
        enemiesNumber--;
    }

    public Vector3 GetPosition(int sideIndex)
    {
        Vector3 position;

        if (sideIndex == 1)
        {
            // left side
            position = new Vector3(xCoord[0], Random.Range(yCoord[0], yCoord[1]), 0f);
        }
        else if (sideIndex == 2)
        {
            // up side
            position = new Vector3(Random.Range(xCoord[0], xCoord[1]), yCoord[1], 0f);
        }
        else if (sideIndex == 3)
        {
            // right side
            position = new Vector3(xCoord[1], Random.Range(yCoord[0], yCoord[1]), 0f);
        }
        else
        {
            // down side
            position = new Vector3(Random.Range(xCoord[0], xCoord[1]), yCoord[0], 0f);
        }

        return position;
    }

    public Vector2 GetVelocity(int sideIndex)
    {
        Vector2 velocity;

        if (sideIndex == 1)
        {
            // left side
            velocity = new Vector2(1f, Random.Range(-1.5f, 1.5f)).normalized;
        }
        else if (sideIndex == 2)
        {
            // up side
            velocity = new Vector2(Random.Range(-1.5f, 1.5f), -1f).normalized;
        }
        else if (sideIndex == 3)
        {
            // right side
            velocity = new Vector2(-1f, Random.Range(-1.5f, 1.5f)).normalized;
        }
        else
        {
            // down side
            velocity = new Vector2(Random.Range(-2f, 2f), 1f).normalized;
        }

        return velocity;
    }

}
