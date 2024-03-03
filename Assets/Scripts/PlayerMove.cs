using System;
using UnityEngine;

[RequireComponent(typeof(Player))]
[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _speedMove;
    [SerializeField] private float _jampForce;
    [SerializeField] private CharacterView _view;

    const string NameAxesHorizontal = "Horizontal";
    const string NameAxesJump = "Jump";

    private Player _player;
    private Rigidbody2D _playerRigidbody;
    private float _radiusCheckGround = 0.1f;
    private SpriteRenderer _playerSprite;

    private StateMachine _stateMachine;

    public CharacterView View => _view;

    private void Awake()
    {
        _view.Initialize();

        _player = GetComponent<Player>();
        _playerRigidbody = transform.GetComponent<Rigidbody2D>();

        _playerSprite = _player.GetComponentInChildren<SpriteRenderer>();

        _stateMachine = new StateMachine(this);

    }

    private void Update()
    {
        if (CheckGround())
        {
            //StateValue?.Invoke(IdleState);
            _stateMachine.SwitchState<IdlingState>();

        }

        if (Input.GetButton(NameAxesHorizontal))
        {
            Run();
        }

        if (CheckGround() && Input.GetButtonDown(NameAxesJump))
        {
            Jump();
        }

        if (Input.GetKey(KeyCode.Q))
        {
            //StateValue?.Invoke(AttackState);
            _stateMachine.SwitchState<AttackingState>();
        }
    }

    private void Jump()
    {
        //StateValue?.Invoke(JumpState);
        _stateMachine.SwitchState<JumpingState>();
        _playerRigidbody.velocity = Vector2.up * _jampForce;
    }

    private void Run()
    {
        Vector3 direction;

        //StateValue?.Invoke(RunState);
        _stateMachine.SwitchState<RunningState>();

        direction = transform.right * Input.GetAxis(NameAxesHorizontal);

        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, _speedMove * Time.deltaTime);

        _playerSprite.flipX = direction.x < 0.0f;
    }

    private bool CheckGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _radiusCheckGround);

        return colliders.Length > 1;
    }
}



