using System.Collections;
using UnityEngine;

/// <summary>
/// Class <c>ShootingEffects</c> provides shooting effects: create bullets and laser ray
/// </summary>
/// 
public class ShootingEffects : MonoBehaviour
{
    [Header("Laser Effect")]
    [SerializeField] private GameObject laserPrefab;
    [SerializeField] private float laserRayLength = 23f;
    [SerializeField] private float laserRayLifeTime = 0.1f;
    [SerializeField] private float recoveryProgressUpdateTime = 0.33f;

    [Header("Components")]
    [SerializeField] private GameObjectCreator bulletCreator;

    WaitForSeconds recoveryInfoTimer;

    private void Awake()
    {
        recoveryInfoTimer = new WaitForSeconds(recoveryProgressUpdateTime);
    }

    public Transform MakeBulletAndGetTransform(Vector3 firePoint, Quaternion rotation)
    {
        return bulletCreator.CreateGameObject(firePoint, rotation);
    }

    public void MakeLaserShooting()
    {
        Transform laserTransform = Instantiate(laserPrefab, transform.position, transform.rotation).GetComponent<Transform>();
        LineRenderer lineRenderer = laserTransform.GetComponent<LineRenderer>();

        if (lineRenderer != null)
        {
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, transform.up * laserRayLength);
        }

        Destroy(laserTransform.gameObject, laserRayLifeTime);
    }

    public IEnumerator RecoveringLaserShoot(Shooting shooting, float laserShootRecoveryTime)
    {
        float recoveringTime = 0;

        while (recoveringTime < laserShootRecoveryTime)
        {
            yield return recoveryInfoTimer;
            recoveringTime += recoveryProgressUpdateTime;
            shooting.RecoveringLaserShoot(recoveringTime);
        }
        
        shooting.RecoverLaserShoot();
    }

}
