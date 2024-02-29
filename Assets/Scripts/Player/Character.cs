
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Character : MonoBehaviour
{
    [SerializeField] private float _speedMove;
    [SerializeField] private float _jampForce;
    [SerializeField] private CharacterView _view;

    const string NameAxesHorizontal = "Horizontal";
    const string NameAxesJump = "Jump";

    private Rigidbody2D _playerRigidbody;
    private StateMachine _stateMachine;

    public CharacterView View => _view;

    public Character(float speedMove, float jampForce, Rigidbody2D playerRigidbody, StateMachine stateMachine)
    {
        _speedMove = speedMove;
        _jampForce = jampForce;
        _playerRigidbody = playerRigidbody;
        _stateMachine = stateMachine;
    }

    private void Awake()
    {
        _stateMachine = new StateMachine();
    }

    private void Update()
    {
        _stateMachine.Update();

        Move();

        //if (Input.GetKeyUp(KeyCode.R))
        //    _stateMachine.SwitchState<RunningState>();

        //if (Input.GetKeyUp(KeyCode.I))
        //    _stateMachine.SwitchState<IdlingState>();

        //if (Input.GetKeyUp(KeyCode.J))
        //    _stateMachine.SwitchState<JumpingState>();




    }

    private void Move()
    {
        Vector3 direction;
        float angleRotationY = 180f;

        direction = transform.right * Input.GetAxis(NameAxesHorizontal);

        if (direction.x < 0.0f)
        {
            transform.Rotate(0, angleRotationY, 0);
            transform.Translate(_speedMove * Time.deltaTime, 0, 0);
            
        }
        else if (direction.x > 0.0f)
        {
            transform.Rotate(0, 0, 0);
            transform.Translate(_speedMove * Time.deltaTime, 0, 0);
            
        }
        else
        {
            _stateMachine.SwitchState<IdlingState>();
        }
    }

}
