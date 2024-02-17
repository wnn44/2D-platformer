using UnityEngine;
using UnityEngine.Events;

public class CollisionWithItems : MonoBehaviour
{
    public UnityEvent HitEventCoin;
    public UnityEvent HitEventKitHealth;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Coin coin))
        {
            Destroy(coin.gameObject);
            HitEventCoin?.Invoke();
        }

        if (collision.TryGetComponent(out KitHealth kitHealth))
        {
            Destroy(kitHealth.gameObject);
            HitEventKitHealth?.Invoke();
        }
    }
}
