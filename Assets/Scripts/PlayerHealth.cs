using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _health;

    private void OnEnable()
    {
        KitHealth.KitHealthFound += Heal;
    }

    private void OnDisble()
    {
        KitHealth.KitHealthFound -= Heal;
    }

    public void Heal(int healValue)
    {
        if (_health < 100)
        {
            _health += healValue;
        }

        if (_health > 100)
        {
            _health = 100;
        }
    }

    public void Damage()
    {
        if (_health != 0)
        {
            _health--;
        }
    }
}
