using TMPro;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField] private int _numberOfCoins;
    [SerializeField] private TextMeshProUGUI _textWalletView;
    [SerializeField] private CollisionDetector _collisionDetector;

    private void OnEnable()
    {
        _collisionDetector.OnCollisionDetectedCoin += AddOne;
    }

    private void OnDisable()
    {
        _collisionDetector.OnCollisionDetectedCoin -= AddOne;
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
