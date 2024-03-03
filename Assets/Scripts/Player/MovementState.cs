using UnityEngine;

public class MovementState : IState
{
    protected const string NameAxesHorizontal = "Horizontal";
    protected const string NameAxesJump = "Jump";
    protected const string NameKeyAttack = "Fire1";

    protected readonly IStateSwitcher StateSwitcher;
    private readonly PlayerMove _playerMove;
    private float _radiusCheckGround = 0.1f;

    public MovementState(IStateSwitcher stateSwitcher, PlayerMove playerMove)
    {
        StateSwitcher = stateSwitcher;
        _playerMove = playerMove;
    }

    protected CharacterView View => _playerMove.View;

    public virtual void Enter()
    {
        Debug.Log(GetType());
    }

    public virtual void Exit()
    {
    }

    public virtual void Update()
    {

        if (CheckGround())
        {
            StateSwitcher.SwitchState<IdlingState>();
        }

        if (Input.GetButton(NameAxesHorizontal))
        {
            Run();
        }

        if (CheckGround() && Input.GetButtonDown(NameAxesJump))
        {
            Jump();
        }

        if (Input.GetButtonDown(NameKeyAttack))
        {
            StateSwitcher.SwitchState<AttackingState>();
        }
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

        direction = _playerMove.transform.right * Input.GetAxis(NameAxesHorizontal);

        _playerMove.transform.position = Vector3.MoveTowards(_playerMove.transform.position, _playerMove.transform.position + direction, _playerMove.Speed * Time.deltaTime);

        _playerMove.PlayerSprite.flipX = direction.x < 0.0f;
    }

    public bool CheckGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(_playerMove.transform.position, _radiusCheckGround);

        return colliders.Length > 1;
    }
}
