using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField] private int _numberOfCoins;

    private void OnEnable()
    {
        CollisionDetector.OnCollisionDetectedCoin += AddOne;
    }

    private void OnDisable()
    {
        CollisionDetector.OnCollisionDetectedCoin -= AddOne;
    }

    public void AddOne(Coin coin)
    {
        if (coin != null)
        {
            _numberOfCoins++;
        }
    }
}
