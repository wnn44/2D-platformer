using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private Health _enemyHealth;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _enemyHealth = GetComponent<Health>();
    }

    private void OnEnable()
    {
        _enemyHealth.HealthZero += HealthZero;
    }

    private void OnDisable()
    {
        _enemyHealth.HealthZero -= HealthZero;
    }

    private void HealthZero()
    {
        float deathGravity = -0.02f;

        _rigidbody.gravityScale = deathGravity;
    }

    public void Damage(int damage)
    {
        _enemyHealth.TakeDamage(damage);

        damage = 0;
    }
}
