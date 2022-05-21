using UnityEngine;

/// <summary>
/// Class <c>Shooting</c> makes shooting with bullets and laser.
/// </summary>
/// 
[System.Serializable]
public class Shooting
{
    #region("Variables")
    // weapon parameters
    [Header("Bullet Shooting Parameters")]
    [SerializeField] private float bulletLifeTime = 5f;
    [SerializeField] private float bulletMass = 0.5f;
    [SerializeField] private float bulletForce = 100f;
    [SerializeField] private float bulletDrag = 0;

    [Header("Laser Shooting Parameters")]
    [SerializeField] private int maxLaserShoots = 4;
    [SerializeField] private float laserShootRecoveryTime = 4f;
    
    // current weapon state
    private int laserShoots = 4;
    public int LaserShoots { get => laserShoots; }

    private bool isRecovering = false;
    public bool IsRecovering { get => isRecovering; }

    private float recoveringProgress = 0f;
    public float RecoveringProgress { get => recoveringProgress; }

    private ShootingEffects shootingEffects;

    #endregion

    public Shooting(ShootingEffects _shootingEffects)
    {
        shootingEffects = _shootingEffects; 
    }

    public void MakeBulletShoot(Transform transform)
    {
        new Bullet(shootingEffects.MakeBulletAndGetTransform(transform.position, transform.rotation),
            bulletMass, transform.up, bulletForce, bulletDrag, bulletLifeTime);
    }

    public void LaserShoot(Transform transform)
    {
        if (laserShoots < 1) return;

        shootingEffects.MakeLaserShooting();
        laserShoots--;

        if (!isRecovering)
        {
            isRecovering = true;
            recoveringProgress = 0f;
            shootingEffects.StartCoroutine(shootingEffects.RecoveringLaserShoot(this, laserShootRecoveryTime));
        }
    }

    public void RecoveringLaserShoot(float _recoveringProgress)
    {
        recoveringProgress = _recoveringProgress / laserShootRecoveryTime;
    }

    public void RecoverLaserShoot()
    {
        laserShoots++;
        if (laserShoots < maxLaserShoots)
        {
            // continue recovering next shoot
            shootingEffects.StartCoroutine(shootingEffects.RecoveringLaserShoot(this, laserShootRecoveryTime));
        }
        else
        {
            isRecovering = false;
        }
    }
}
