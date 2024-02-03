using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public static event Action CoinFound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out PlayerType playerType))        
        {
            CoinFound?.Invoke();

            Destroy(gameObject);
        }
    }
}
