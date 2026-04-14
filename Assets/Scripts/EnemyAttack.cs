using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private float _damageAmount;

    public float DamageAmount { get; private set; }

    private void Start()
    {
        DamageAmount=_damageAmount;
    }
}
