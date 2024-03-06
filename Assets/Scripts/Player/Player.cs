using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Player : MonoBehaviour
{
    [SerializeField] private int _health = 100;
    [SerializeField] private float _speedMove;
    [SerializeField] private float _jampForce;
    [SerializeField] private CharacterView _view;

    private SpriteRenderer _playerSprite;
    private Rigidbody2D _playerRigidbody;
    private StateMachine _stateMachine;
    private PlayerHealth _playerHealth;

    public CharacterView View => _view;
    public float Speed => _speedMove;
    public float JampForce => _jampForce;
    public Rigidbody2D Rigidbody => _playerRigidbody;
    public SpriteRenderer PlayerSprite => _playerSprite;
    public int Health => _health;

    private void Awake()
    {
        _view.Initialize();

        _playerRigidbody = transform.GetComponent<Rigidbody2D>();

        _playerSprite = GetComponentInChildren<SpriteRenderer>();

        _playerHealth = GetComponentInChildren<PlayerHealth>();

        _stateMachine = new StateMachine(this);
    }

    private void Update()
    {
        _stateMachine.Update();
    }

    private void FixedUpdate()
    {
        _stateMachine.FixedUpdate();
    }

    private void OnEnable()
    {
        EnemyAttack.OnAttack += Damage;
        CollisionDetector.OnCollisionDetectedKitHealth += Heal;
    }

    private void OnDisable()
    {
        EnemyAttack.OnAttack -= Damage;
        CollisionDetector.OnCollisionDetectedKitHealth -= Heal;
    }

    private void Damage()
    {
        _health = _playerHealth.Damage(_health);
    }

    private void Heal(int healValue)
    {
        _health = _playerHealth.Heal(_health, healValue);
    }
}



