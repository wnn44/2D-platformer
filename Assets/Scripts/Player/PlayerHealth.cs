using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 100;
    [SerializeField] private int _minHealth = 0;

    public int Heal(int health, int healValue)
    {
        health += healValue;
        health = Mathf.Clamp(health, _minHealth, _maxHealth);
        return health;
    }

    public int Damage(int health)
    {
        health--;
        health = Mathf.Clamp(health, _minHealth, _maxHealth);
        return health;
    }
}
