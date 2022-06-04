using UnityEngine;


public class Enemy
{
    private Transform transform;
    public Transform EnemyTransform { get => transform; }
    private Body body;
    private EnemyCharacter character;
    private Player player;
    private EnemyCreator enemyCreator;
   
    private int pointsAsReward = 1; // reward for player when kills this enemy
    private int deathCounter = 0; // 0 -> death, 1 -> spawn new small enemies


    public Enemy(Transform _transform, int _points, int _deathCounter, Player _player, EnemyCreator _enemyCreator)
    {
        pointsAsReward = _points;
        deathCounter = _deathCounter;
        transform = _transform;
        character = _transform.GetComponent<EnemyCharacter>();
        character.SetEnemy(this);
        player = _player;
        enemyCreator = _enemyCreator;
    }

    public void SetBody(Body _body)
    {
        body = _body;
    }

    public void MoveForwardAndRotate(float v, float h, float deltaT, Vector2 direction)
    {
        body.MoveByForce(v, deltaT, transform, direction);

        if (h != 0) body.Rotate(h, transform);
    }

    public Vector3 PlayerPosition()
    {
        return player.GetPosition();
    }

    public virtual void MoveEnemy(float deltaT)
    {
        // specified in children's classes
    }

    public void EnemyDied(bool byLaser = false)
    {
        // add score to player
        player.AddPoints(pointsAsReward);
        
        if (deathCounter == 0 || byLaser)
        {
            DestroyCharacter();
            return;
        }

        deathCounter--;
        CreateSmallEnemies();
    }

    private void CreateSmallEnemies()
    {
        // create small if needed
        if (enemyCreator != null) enemyCreator.CreateSmallEnemies(transform.position);

        DestroyCharacter();
    }

    private void DestroyCharacter()
    {
        enemyCreator.EnemyHasDied();
        character.StopEnemy();
    }

}

