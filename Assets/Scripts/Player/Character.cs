
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private float _speedMove;
    [SerializeField] private float _jampForce;

    const string NameAxesHorizontal = "Horizontal";
    const string NameAxesJump = "Jump";

    private Rigidbody2D _playerRigidbody;
    private StateMachine _stateMachine;

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

        //if (Input.GetKeyUp(KeyCode.R))
        //    _stateMachine.SwitchState<RunningState>();

        //if (Input.GetKeyUp(KeyCode.I))
        //    _stateMachine.SwitchState<IdlingState>();

        //if (Input.GetKeyUp(KeyCode.J))
        //    _stateMachine.SwitchState<JumpingState>();

        Vector3 velocity;
        float direction;

        direction = Input.GetAxis(NameAxesHorizontal);
        velocity = transform.right * direction;

        transform.position = Vector3.MoveTowards(transform.position, transform.position + velocity, _speedMove * Time.deltaTime);
        transform.rotation = GetRotationFrom(direction);

    }

    private Quaternion GetRotationFrom(float direction)
    {
        if(direction > 0)
        {
            return new Quaternion(0, 0, 0, 0);
        }

        if (direction < 0)
        {
            return Quaternion.Euler(0,180,0);
        }

        return transform.rotation;
    }
}
