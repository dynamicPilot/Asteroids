using UnityEngine;

public class BulletCharacter : MonoBehaviour
{
    private Bullet bullet;
    private bool pauseUpdate = true;
    public void StartBullet(Bullet newBullet)
    {
        bullet = newBullet;
        pauseUpdate = false;
    }
    private void FixedUpdate()
    {
        if (pauseUpdate) return;

        bullet.MoveBullet(Time.fixedDeltaTime);
    }

    public void StopBullet(float lifeTime)
    {
        Destroy(gameObject, lifeTime);
    }
}
