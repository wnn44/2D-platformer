using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _health;

    private void OnEnable()
    {
        KitHealth.KitHealthFound += Add;
    }

    private void OnDisble()
    {
        KitHealth.KitHealthFound -= Add;
    }

    public void Add(int healValue)
    {
        if (_health < 100)
        {
            _health += healValue;
        }
    }

    public void Decrease()
    {
        if (_health != 0)
        {
            _health--;
        }
    }
}
