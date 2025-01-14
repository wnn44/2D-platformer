using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Health))]

public class Player : MonoBehaviour
{
    [SerializeField] private float _speedMove;
    [SerializeField] private float _jampForce;
    [SerializeField] private CharacterView _view;
    [SerializeField] private CollisionDetector _collisionDetector;
    [SerializeField] private EnemyAttack _enemyAttack;
    [SerializeField] private Vampirism _vampirism;

    public CharacterView View => _view;
    public float Speed => _speedMove;
    public float JampForce => _jampForce;
    public Rigidbody2D Rigidbody => _playerRigidbody;
    public SpriteRenderer PlayerSprite => _playerSprite;

    private SpriteRenderer _playerSprite;
    private Rigidbody2D _playerRigidbody;
    private StateMachine _stateMachine;
    private Health _playerHealth;
    private int _damageEnemy;
    private bool _activateVampirism;

    private void Awake()
    {
        _view.Initialize();

        _playerRigidbody = transform.GetComponent<Rigidbody2D>();

        _playerSprite = GetComponentInChildren<SpriteRenderer>();

        _playerHealth = GetComponent<Health>();

        _stateMachine = new StateMachine(this);
    }

    private void FixedUpdate()
    {
        _stateMachine.FixedUpdate();

        if (_activateVampirism)
            Vampirism();
    }

    private void Update()
    {
         _stateMachine.Update();

        _activateVampirism = Input.GetKey(KeyCode.N);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.Damage(_damageEnemy);

            _damageEnemy = 0;
        }
    }

    private void OnEnable()
    {
        _enemyAttack.Attack += Damage;
        _collisionDetector.OnCollisionDetectedKitHealth += Heal;
        _playerHealth.Died += HealthZero;
    }

    private void OnDisable()
    {
        _enemyAttack.Attack -= Damage;
        _collisionDetector.OnCollisionDetectedKitHealth -= Heal;
        _playerHealth.Died -= HealthZero;
    }

    public void DamageEnemy(int damageEnemy)
    {
        _damageEnemy = damageEnemy;
    }

    private void HealthZero()
    {
        float deathGravity = -0.02f;

        gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
        Rigidbody.gravityScale = deathGravity;
    }

    private void Damage(int damage)
    {
        _playerHealth.TakeDamage(damage);
    }

    private void Heal(KitHealth healValue)
    {
        _playerHealth.TakeHeal(healValue.HealValue);
    }
    
    private void Vampirism()
    {
        _vampirism.ViewSprite();
    }
}



