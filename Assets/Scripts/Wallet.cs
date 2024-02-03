using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField] private int _numberOfCoins;

    private void OnEnable()
    {
        Coin.CoinFound += AddOne;
    }

    private void OnDisble()
    {
        Coin.CoinFound -= AddOne;
    }

    public void AddOne()
    {
        _numberOfCoins++;
    }
}
