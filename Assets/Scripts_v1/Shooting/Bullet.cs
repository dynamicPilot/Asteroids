using UnityEngine;

public class Bullet
{
    Body body;
    Transform transform;
    public Bullet(Transform _transform, float mass, Vector2 impulseForceVector, float impulseForce, float dragCoeff, float lifeTime)
    {
        transform = _transform;
        body = new Body(mass, dragCoeff);

        // move bullet by impulse force
        body.MoveByForce(impulseForce, Time.fixedDeltaTime, _transform, impulseForceVector);

        // destroy object after lifeTime
        BulletCharacter character = transform.GetComponent<BulletCharacter>();
        character.StartBullet(this);
        character.StopBullet(lifeTime);
    }

    public void MoveBullet(float deltaT)
    {
        body.MoveByForce(0, deltaT, transform, transform.up);
    }
}
