using System;
using UnityEngine;

public class MovementState : IState
{
    protected const string AxesHorizontal = "Horizontal";
    protected const string AxesJump = "Jump";
    protected const string KeyAttack = "Fire1";
    protected const string NameGroundLayerMask = "Platform";
    protected const KeyCode KeyVampirizm = KeyCode.N;

    protected readonly IStateSwitcher StateSwitcher;

    private readonly Player _playerMove;
    private float _radiusCheckGround = 0.1f;
    private int _damageEnemy = 20;
    private float _horizontalDirection;
    private LayerMask _groundLayerMask;
    private bool _horizontal;
    private bool _jump;
    private bool _attack;
    private bool _activateVampirism;

    public static event Action ActionVampirism;

    protected CharacterView View => _playerMove.View;

    public MovementState(IStateSwitcher stateSwitcher, Player playerMove)
    {
        StateSwitcher = stateSwitcher;
        _playerMove = playerMove;
    }

    public virtual void FixedUpdate()
    {
        if (CheckGround())
            StateSwitcher.SwitchState<IdlingState>();

        if (_horizontal)
            Run();

        if (_jump)
        {
            Jump();

            _jump = false;
        }

        if (_attack && _horizontal == false)
        {
            StateSwitcher.SwitchState<AttackingState>();

            _playerMove.DamageEnemy(_damageEnemy);
        }

        if (_activateVampirism)
        {
            ActionVampirism?.Invoke();

            _activateVampirism = false;
        }
    }

    public virtual void Update()
    {
        _horizontalDirection = Input.GetAxis(AxesHorizontal);
        _horizontal = Input.GetButton(AxesHorizontal);
        _attack = Input.GetButton(KeyAttack);

        if (CheckGround() && Input.GetButton(AxesJump))
        {
            _jump = true;
        }

        if (Input.GetKeyDown(KeyVampirizm))
        {
            _activateVampirism = true;
        }
    }

    public virtual void Enter() { }

    public virtual void Exit() { }

    public bool CheckGround()
    {
        if (_groundLayerMask == 0)
        {
            _groundLayerMask = 1 << LayerMask.NameToLayer(NameGroundLayerMask);
        }       

        Collider2D[] colliders = Physics2D.OverlapCircleAll(_playerMove.transform.position, _radiusCheckGround, _groundLayerMask);

        return colliders.Length > 1;
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
}
