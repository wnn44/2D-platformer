using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _maxHealth = 100;
    [SerializeField] private int _minHealth = 0;
    [SerializeField] private int _healValue = 20;

    public void Heal()
    {
        _health += _healValue;
        _health = Mathf.Clamp(_health, _minHealth, _maxHealth);
    }

    public void Damage()
    {
        _health--;
        _health = Mathf.Clamp(_health, _minHealth, _maxHealth);
    }
}
