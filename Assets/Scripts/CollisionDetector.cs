using System;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    public event Action<Coin> OnCollisionDetectedCoin;
    public event Action<KitHealth> OnCollisionDetectedKitHealth;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Coin coin))
        {
            OnCollisionDetectedCoin?.Invoke(coin);
        }

        if (collision.TryGetComponent(out KitHealth kitHealth))
        {
            OnCollisionDetectedKitHealth?.Invoke(kitHealth);
        }
    }
}
