using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField] int _numberOfCoins;

    public void AddOne()
    {
        _numberOfCoins++;
    }
}
