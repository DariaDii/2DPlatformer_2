using UnityEngine;

public class HealingItem : MonoBehaviour
{
    [SerializeField] private float _healingAmount;

    public float HealingAmount { get; private set;  }

    private void Start()
    {
        HealingAmount = _healingAmount;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent<Player>(out _))
        {
            Destroy(this.gameObject);
        }
    }
}
