using System;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform _startPoint;
    [SerializeField] private Transform _endPoint;
    [SerializeField] private float _speed;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private float _attackRange = 1.5f;

    private Transform _currentPoint;
    private float _distanceToTargetPoint = 0.1f;
    private bool _isMoving = false;

    public event Action<bool> Patrolling;

    private void Start()
    {
        _currentPoint=_startPoint;
    }

    public void UpdateEnemy(Transform playerTransform)
    {
        if (playerTransform != null)
        {
            Vector3 toPlayer = playerTransform.position - transform.position;
            float distance = toPlayer.sqrMagnitude;

            if (distance < _attackRange * _attackRange)
            {
                Attack();
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, _speed * Time.deltaTime);
                _currentPoint = playerTransform;
                TurnToCurrentPoint();
            }


        }
        else
        {
            Patroll();
        }
    }

    public void Patroll()
    { 
        _isMoving = true;
        transform.position = Vector3.MoveTowards(transform.position,_currentPoint.position,_speed*Time.deltaTime);

        Vector3 toTarget = _currentPoint.position - transform.position;
        float distance = toTarget.sqrMagnitude;

        if (distance < _distanceToTargetPoint * _distanceToTargetPoint)
        {
            if (_currentPoint == _startPoint)
                _currentPoint = _endPoint;
            else
                _currentPoint = _startPoint;
        }

        Patrolling?.Invoke(_isMoving);

        TurnToCurrentPoint();
    }

    private void TurnToCurrentPoint()
    {
        _spriteRenderer.flipX = _currentPoint.position.x > transform.position.x;
    }

    private void Attack()
    {
        Debug.Log("Враг атакует!");
    }
}
