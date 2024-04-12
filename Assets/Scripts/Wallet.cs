using TMPro;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField] private int _numberOfCoins;
    [SerializeField] private TextMeshProUGUI _textWalletView;

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

        _textWalletView.text = _numberOfCoins.ToString();
    }
}
