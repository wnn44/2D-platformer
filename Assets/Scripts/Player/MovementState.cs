using UnityEngine;

public class MovementState : IState
{
    protected const string AxesHorizontal = "Horizontal";
    protected const string AxesJump = "Jump";
    protected const string KeyAttack = "Fire1";

    protected readonly IStateSwitcher StateSwitcher;
    private readonly Player _playerMove;
    private float _radiusCheckGround = 0.1f;
    private int _damageEnemy = 20;

    private float _horizontalDirection;
    private bool _horizontal;
    private bool _jump;
    private bool _attack;

    public MovementState(IStateSwitcher stateSwitcher, Player playerMove)
    {
        StateSwitcher = stateSwitcher;
        _playerMove = playerMove;
    }

    protected CharacterView View => _playerMove.View;

    public virtual void FixedUpdate()
    {
        if (CheckGround())
            StateSwitcher.SwitchState<IdlingState>();

        if (_horizontal)
            Run();

        if (CheckGround() && _jump)
            Jump();

        if (_attack && _horizontal == false)
        {
            StateSwitcher.SwitchState<AttackingState>();

            _playerMove.DamageEnemy(_damageEnemy);
        }
    }

    public virtual void Update()
    {
        _horizontalDirection = Input.GetAxis(AxesHorizontal);
        _horizontal = Input.GetButton(AxesHorizontal);
        _jump = Input.GetButton(AxesJump);
        _attack = Input.GetButton(KeyAttack);
    }

    private void Jump()
    {
        StateSwitcher.SwitchState<JumpingState>();
        _playerMove.Rigidbody.velocity = Vector2.up * _playerMove.JampForce;
    }

    private void Run()
    {
        Vector3 direction;

        StateSwitcher.SwitchState<RunningState>();

        direction = _playerMove.transform.right * _horizontalDirection;

        _playerMove.transform.position = Vector3.MoveTowards(_playerMove.transform.position, _playerMove.transform.position + direction, _playerMove.Speed * Time.deltaTime);

        _playerMove.PlayerSprite.flipX = direction.x < 0.0f;
    }

    public bool CheckGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(_playerMove.transform.position, _radiusCheckGround);

        return colliders.Length > 1;
    }

    public virtual void Enter() { }

    public virtual void Exit() { }
}
