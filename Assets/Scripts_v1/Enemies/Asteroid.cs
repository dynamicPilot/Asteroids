using UnityEngine;

public class Asteroid: Enemy
{
    private int rotationDirection = 1;
    public Asteroid(Transform _transform, Player _player, Vector2 _velocity, float _angularVelocity, int _rotationDirection, int _points,
        EnemyCreator _enemyCreator, int _deathCounter = 1) : 
        base(_transform, _points, _deathCounter, _player, _enemyCreator)
    {
        // create body
        SetBody(new Body(_velocity, _angularVelocity));       
        rotationDirection = _rotationDirection;
    }

    public override void MoveEnemy(float deltaT)
    {
        MoveForwardAndRotate(0f, rotationDirection, deltaT, base.EnemyTransform.up);
    }
}
