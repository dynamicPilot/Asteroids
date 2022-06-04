using UnityEngine;

/// <summary>
/// Class <c>Player</c> - main player class
/// Requares playerCharacter Component
/// Contains Body and Shooting classes for the player
/// </summary>
/// 

[System.Serializable]
public class Player
{
    #region("Variables")
    
    // player parameters 
    [SerializeField] private float pushForce = 100f; // engine push force magnitude
    [SerializeField] private float mass = 8f;
    [SerializeField] private float dragCoef = 20f;
    [SerializeField] private float angularVelocity = 3f; // degree per keyboard button single press
    [SerializeField] private float velocitySensetivity = 0.06f; // if velocity magnitude is less -> set velocity to zero

    public delegate void PlayerHasDiedDelegate();
    public event PlayerHasDiedDelegate OnPlayerHasDied;

    private int score = 0;
    public int Score { get => score; }

    private Transform transform;
    [SerializeField] private Body body; // movement 
    public Body PlayerBody { get => body; }
    [SerializeField] private Shooting shooting; // shooting
    public Shooting PlayerShooting { get => shooting; }

    private PlayerCharacter character;

    #endregion
    public Player()
    {        
        score = 0;
    }

    public void SetPlayer(Transform _transform)
    {
        transform = _transform;
        score = 0;

        shooting = new Shooting(transform.GetComponent<ShootingEffects>());
        body = new Body(mass, dragCoef, velocitySensetivity, angularVelocity);

        character = transform.GetComponent<PlayerCharacter>();
        if (character != null) character.SetCharacter(this);
    }

    public void StartPlayer()
    {
        if (character != null) character.StartCharacter();
    }

    public void MoveForwardAndRotate(float v, float h, float deltaT)
    {
        // move
        body.MoveByForce(v * pushForce, deltaT, transform, transform.up);

        // rotate
        body.Rotate(h, transform);
    }

    public void BulletShooting()
    {
        shooting.MakeBulletShoot(transform);
    }

    public void LaserShooting()
    {
        shooting.LaserShoot(transform);
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public float GetAngle()
    {
        float temp = transform.eulerAngles.z;

        if (temp > 180) temp = 360 - temp;
        return temp;
    }

    public void PlayerHasDied()
    {
        // stop update character and turn off collider
        if (character != null) character.StopCharacter();

        if (OnPlayerHasDied != null) OnPlayerHasDied.Invoke();
    }

    public void AddPoints(int amount)
    {
        score += amount;
    }

}
