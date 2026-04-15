using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyMovement _movement;
    [SerializeField] private EnemyHealth _health;
    [SerializeField] private EnemyDetection _detection;

    private void Update()
    {
        _movement.UpdateEnemy(_detection.PlayerPosition);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Sword>(out _))
        {
            _health.TakeDamage();
        }
    }
}
