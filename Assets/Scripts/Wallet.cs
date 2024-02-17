using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField] private int _numberOfCoins;

    public void AddOne()
    {
        _numberOfCoins++;
    }
}
