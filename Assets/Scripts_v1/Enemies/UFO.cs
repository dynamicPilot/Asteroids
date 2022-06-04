using UnityEngine;

public class UFO : Enemy
{
    private float pushForse = 2f;

    public UFO (Transform _transform, Player _player, EnemyCreator _enemyCreator, int _points = 20, float _mass = 10f, float _pushForse = 60f, float _dragCoef = 10f) : 
        base(_transform, _points, 0, _player, _enemyCreator)
    {
        //mass = newMass;
        pushForse = _pushForse;
        SetBody(new Body(_mass, _dragCoef));
    }
    public override void MoveEnemy(float deltaT)
    {
        Vector2 direction = (PlayerPosition() - base.EnemyTransform.position).normalized;
        MoveForwardAndRotate(pushForse, 0f, deltaT, direction);
    }
}
