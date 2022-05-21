using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Player player;

    private bool pauseUpdate = true;
    public bool PauseUpdate { set => pauseUpdate = value; }
    private int fireRate = 0;
    private float timeToFire = 0;

    private void Awake()
    {
        pauseUpdate = true;
    }

    public void SetController(Player newPlayer)
    {
        player = newPlayer;
        if (player == null)
        {
            Debug.LogError("PlayerController: no player!");
        }
    }

    private void Update()
    {
        if (pauseUpdate) return;

        // fire rate and timeToFire need to prevent so many bullets
        if (fireRate != 0)
        {
            // decrease timer
            timeToFire -= Time.deltaTime;
            if (timeToFire <= 0) fireRate = 0;
        }

        if (Input.GetButtonDown("BulletFire") && fireRate == 0)
        {
            // bullet shooting
            player.BulletShooting();
            fireRate++;
            timeToFire = 0.5f;            
        }

        if (Input.GetButtonDown("LaserFire"))
        {
            // laser shooting
            player.LaserShooting();
        }
    }

    private void FixedUpdate()
    {
        if (pauseUpdate) return;

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if (h > 0) h = -1f;
        else if (h < 0) h = 1f;

        if (v > 0) v = 1f; // only forward movement is allowed
        else v = 0;

        player.MoveForwardAndRotate(v, h, Time.fixedDeltaTime);
    }

}
