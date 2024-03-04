using System;
using UnityEngine;
using UnityEngine.Events;

public class CollisionDetector : MonoBehaviour
{
    public static event Action OnCollisionDetectedCoin;
    public static event Action<int> OnCollisionDetectedKitHealth;
    public static event Action OnDestroyKitHealth;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Coin coin))
        {
            OnCollisionDetectedCoin?.Invoke();
            Destroy(coin.gameObject);
        }

        if (collision.TryGetComponent(out KitHealth kitHealth))
        {
            OnCollisionDetectedKitHealth?.Invoke(kitHealth.HealValue);
            Destroy(kitHealth.gameObject);
            OnDestroyKitHealth?.Invoke();
        }
    }
}
