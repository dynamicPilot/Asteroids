using UnityEngine;

/// <summary>
/// Class <c>Body</c> moves and rotates transform.
/// </summary>

[System.Serializable]
public class Body
{
    // body parameters
    [SerializeField] private Vector2 velocity = Vector2.zero;
    [SerializeField] private Vector2 acceleration = Vector2.zero;
    [SerializeField] private float angularVelocity = 10f;
    [SerializeField] private float dragCoef = 1f;
    [SerializeField] private float mass = 1f;

    private float sensetivity = 0.01f; // if velocity magnitude is less -> set velocity to zero

    #region("Class init")
    public Body()
    {
        // create with default params
    }

    public Body(float _mass, float _dragCoef, float _sensitivity, float _angularVelocity)
    {
        // standard body
        velocity = Vector2.zero;
        acceleration = Vector2.zero;
        sensetivity = _sensitivity;
        angularVelocity = _angularVelocity;
        dragCoef = _dragCoef;
        mass = _mass;
    }

    public Body(Vector2 _velocity, float _angularVelocity)
    {
        // asteroid body
        mass = 10f;
        angularVelocity = _angularVelocity;
        velocity = _velocity;
        acceleration = Vector2.zero;
        dragCoef = 0f;       
        sensetivity = 0.02f;
    }

    public Body(float _mass, float _dragCoef)
    {
        // UFO body
        velocity = Vector2.zero;
        acceleration = Vector2.zero;
        dragCoef = _dragCoef;
        mass = _mass;
        angularVelocity = 0f;
    }

    #endregion

    public void Rotate(float direction, Transform transform)
    {
        // rotates transform by angularVelocity value according to direction
        transform.Rotate(0f, 0f, direction * angularVelocity);
    }

    public void MoveByForce(float force, float deltaT, Transform transform, Vector2 forceDirectionVector)
    {
        // move by force according to forceDirectionVector       
        Vector2 forceVector = forceDirectionVector * force;

        if (mass == 0) mass = 0.001f;

        // acceleration
        acceleration = (forceVector + (-1) * velocity.normalized * velocity.magnitude * velocity.magnitude * dragCoef) / mass;
        
        // move
        Vector2 newPosition = new Vector2(transform.position.x, transform.position.y) + velocity * deltaT + acceleration * deltaT * deltaT / 2;
        transform.position = new Vector3(newPosition.x, newPosition.y, transform.position.z);

        // new velocity
        velocity += acceleration * deltaT;
        if (velocity.magnitude < sensetivity) velocity = Vector2.zero;
    }

    public float GetVelocity()
    {
        return velocity.magnitude;
    }
}
