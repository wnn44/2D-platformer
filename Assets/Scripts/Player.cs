using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speedMove;
    [SerializeField] private float _jampForce;

    const string NameParametrAnimation = "State";
    const string NameAxesHorizontal = "Horizontal";
    const string NameAxesJump = "Jump";

    private PlayerType _player;
    private Rigidbody2D _playerRigidbody;
    private float _radiusCheckGround = 0.1f;
    private SpriteRenderer _playerSprite;

    private Animator _animation;

    private States _states
    {
        get { return (States)_animation.GetInteger(NameParametrAnimation); }
        set { _animation.SetInteger(NameParametrAnimation, (int)value); }
    }

    private void Start()
    {
        _player = GetComponent<PlayerType>();
        _playerRigidbody = transform.GetComponent<Rigidbody2D>();
        _playerSprite = _player.GetComponentInChildren<SpriteRenderer>();

        _animation = _player.GetComponent<Animator>();
    }

    private void Update()
    {
        if (CheckGround())
        {
            _states = States.Idle;
        }

        if (Input.GetButton(NameAxesHorizontal))
        {
            Run();
        }

        if (CheckGround() && Input.GetButtonDown(NameAxesJump))
        {
            Jump();
        }
    }

    private void Jump()
    {
        _states = States.Jump;
        _playerRigidbody.velocity = Vector2.up * _jampForce;
    }

    private void Run()
    {
        Vector3 direction;

        if (CheckGround())
        {
            _states = States.Run;
        }

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

public enum States
{
    Idle,
    Run,
    Jump
}




