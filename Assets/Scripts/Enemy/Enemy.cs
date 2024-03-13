using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health = 1000;
    [SerializeField] private int _maxHealth = 1000;
    [SerializeField] private int _minHealth = 0;

    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (_health <= 0)
        {
            float deathGravity = -0.02f;

            _rigidbody.gravityScale = deathGravity;
        }
    }

    public void Damage(int damage)
    {
        _health -= damage;
        _health = Mathf.Clamp(_health, _minHealth, _maxHealth);

        damage = 0;
    }
}
