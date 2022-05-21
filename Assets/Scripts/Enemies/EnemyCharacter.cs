using UnityEngine;

public class EnemyCharacter : MonoBehaviour
{
    private Enemy enemy;
    public Enemy EnemyClass { get => enemy; }
    private bool pauseUpdate = true;

    public void SetEnemy(Enemy newEnemy)
    {
        enemy = newEnemy;
        pauseUpdate = false;
    }

    private void FixedUpdate()
    {
        if (pauseUpdate) return;

        enemy.MoveEnemy(Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            // spawn new if needed
            enemy.EnemyDied();
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Laser"))
        {
            // no spawn new -> laser hit
            enemy.EnemyDied(true);
        }
    }

    public void StopEnemy()
    {
        pauseUpdate = true;
        Destroy(gameObject);
    }
}
