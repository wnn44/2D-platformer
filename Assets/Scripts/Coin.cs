using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Hero")
        {
            FindObjectOfType<Wallet>().AddOne();

            Destroy(gameObject);

            FindObjectOfType<SpawnCoin>().Spawn();
        }
    }
}
