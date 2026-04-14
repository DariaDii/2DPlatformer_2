using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public event Action<Coin> Touched;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out _))
        {
            Touched?.Invoke(this);
        }
    }
}