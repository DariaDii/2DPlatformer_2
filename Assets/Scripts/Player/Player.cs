using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GroundDetector _groundDetector;
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private Mover _mover;
    [SerializeField] private Rotator _rotator;
    [SerializeField] private Wallet _wallet;
    [SerializeField] private Health _health;
    [SerializeField] private Attack _attack;

    private void Update()
    {
        if (_inputReader.GetIsAttack())
        {
            _attack.Attacking();
        }
    }

    private void FixedUpdate()
    {
        if (_inputReader.Direction != 0)
        {
            _rotator.Rotate(_inputReader.Direction);            
        }

        _mover.Move(_inputReader.Direction);

        if (_inputReader.GetIsJump() && _groundDetector.IsGround)
        {
            _mover.Jump();
            _inputReader.ResetJumpFlag();
        }            
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Coin>(out _))
        {
            _wallet.AddCoin();
        }

        if(collision.gameObject.TryGetComponent<HealingItem>(out HealingItem healingItem))
        {
            _health.Heal(healingItem.HealingAmount);
        }

        if (collision.gameObject.TryGetComponent<EnemyAttack>(out EnemyAttack enemyAttack))
        {
            _health.TakeDamage(enemyAttack.DamageAmount);
        }
    }
}