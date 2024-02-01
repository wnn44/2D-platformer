using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<Wallet>().AddOne();

        Destroy(gameObject);
    }
}
