using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private Collider2D _attackPoint;

    public void Attacking()
    {
        _attackPoint.gameObject.SetActive(true);
    }

    public void FinishAttack()
    {
        _attackPoint.gameObject.SetActive(false);
    }
}
