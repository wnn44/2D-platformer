using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField] int _numberOfCoins;

    private void OnEnable()
    {
        Coin.FoundCoin += AddOne;
    }

    private void OnDisble()
    {
        Coin.FoundCoin -= AddOne;
    }

    public void AddOne()
    {
        _numberOfCoins++;
    }
}
