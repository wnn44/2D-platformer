using System;
using UnityEngine;

[RequireComponent(typeof(PlayerType))]
[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _speedMove;
    [SerializeField] private float _jampForce;

    const string NameAxesHorizontal = "Horizontal";
    const string NameAxesJump = "Jump";

    const int IdleState = 0;
    const int RunState = 1;
    const int JumpState = 2;
    const int AttackState = 3;

    public static event Action<int> StateValue;

    private PlayerType _player;
    private Rigidbody2D _playerRigidbody;
    private float _radiusCheckGround = 0.1f;
    private SpriteRenderer _playerSprite;

    private void Start()
    {
        _player = GetComponent<PlayerType>();
        _playerRigidbody = transform.GetComponent<Rigidbody2D>();

        _playerSprite = _player.GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        if (CheckGround())
        {
            StateValue?.Invoke(IdleState);
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
            StateValue?.Invoke(AttackState);
        }
    }

    private void Jump()
    {
        StateValue?.Invoke(JumpState);
        _playerRigidbody.velocity = Vector2.up * _jampForce;
    }

    private void Run()
    {
        Vector3 direction;

        StateValue?.Invoke(RunState);

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



