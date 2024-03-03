using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Player : MonoBehaviour
{
    [SerializeField] private float _speedMove;
    [SerializeField] private float _jampForce;
    [SerializeField] private CharacterView _view;

    private SpriteRenderer _playerSprite;
    private Rigidbody2D _playerRigidbody;
    private StateMachine _stateMachine;

    public CharacterView View => _view;
    public float Speed => _speedMove;
    public float JampForce => _jampForce;
    public Rigidbody2D Rigidbody => _playerRigidbody;
    public SpriteRenderer PlayerSprite => _playerSprite;

    private void Awake()
    {
        _view.Initialize();

        _playerRigidbody = transform.GetComponent<Rigidbody2D>();

        _playerSprite = GetComponentInChildren<SpriteRenderer>();

        _stateMachine = new StateMachine(this);
    }

    private void Update()
    {
        _stateMachine.Update();
    }
}



