using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    public const string IsWalk = "IsWalk";
    public const string Damage = "Damage";
    public const string Death = "Death";

    [SerializeField] private Animator _animator;
    [SerializeField] private EnemyMovement _enemy;
    [SerializeField] private EnemyHealth _enemyHealth;

    private void OnEnable()
    {
        _enemy.Patrolling += UpdateWalkAnimation;
        _enemyHealth.Death += StartDeathAnimaion;
        _enemyHealth.ReceivingDamage += StartDamage;
    }

    private void OnDisable()
    {
        _enemy.Patrolling -= UpdateWalkAnimation;
        _enemyHealth.Death -= StartDeathAnimaion;
        _enemyHealth.ReceivingDamage -= StartDamage;
    }

    private void UpdateWalkAnimation(bool isWalking)
    {
        _animator.SetBool(IsWalk, isWalking);
    }

    private void StartDeathAnimaion()
    {
        _animator.SetTrigger(Death);
    }
    private void StartDamage()
    {
        _animator.SetTrigger(Damage);
    }
}
