using System;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float _health = 3;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Collider2D _collider;

    public event Action Death;
    public event Action ReceivingDamage;


    public void TakeDamage()
    {
        ReceivingDamage?.Invoke();
        _health--;

        if (_health < 0 )
            _health = 0;

        if (_health == 0)
            Die();
    }

    private void Die()
    {
        Death?.Invoke();
        _rigidbody.simulated=false;
        _collider.gameObject.SetActive(false);
    }
}
