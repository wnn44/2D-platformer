using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public static event Action FoundCoin;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerType>() != null)
        {
            FoundCoin?.Invoke();

            Destroy(gameObject);
        }
    }
}
