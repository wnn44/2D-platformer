using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Health))]
public class Enemy : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private Health _enemyHealth;

    public void Damage(int damage)
    {
        _enemyHealth.TakeDamage(damage);
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _enemyHealth = GetComponent<Health>();
    }

    private void OnEnable()
    {
        _enemyHealth.Died += HealthZero;
    }

    private void OnDisable()
    {
        _enemyHealth.Died -= HealthZero;
    }

    private void HealthZero()
    {
        float deathGravity = -0.02f;

        _rigidbody.gravityScale = deathGravity;
    }
}
