using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private float _baseSpeed;
    [SerializeField] private LayerMask _platformLayer;
    [SerializeField] private EnemySprite _sprite;
    [SerializeField] private EnemyAttack _enemyAttack;

    private float _angleRotationY = 180;
    private float _speed;

    public Vector3 Direction { get; private set; }

    public void StopMove()
    {
        float minSpeed = 0.01f;

        _speed = minSpeed;
    }

    public void StartMove()
    {
        _speed = _baseSpeed;
    }

    private void Start()
    {
        Direction = transform.right;

        _speed = _baseSpeed;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (!CheckingEndOfPath())
        {
            ChangeDirection();
        }

        transform.position = Vector3.MoveTowards(transform.position, transform.position + Direction, _speed * Time.deltaTime);
    }

    private bool CheckingEndOfPath()
    {
        float offset = 0.3f;
        float distanceDown = 1f;

        RaycastHit2D hit = Physics2D.Raycast(transform.position + Direction * offset, Vector3.down, distanceDown, _platformLayer);

        return (hit.collider != null);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out TileMap tileMap))
        {
            ChangeDirection();
        }
    }

    private void ChangeDirection()
    {
        int reverseDirection = -1;
        Direction *= reverseDirection;

        _sprite.transform.Rotate(0, _angleRotationY, 0);
    }

    private void OnEnable()
    {
        _enemyAttack.OnCollision += StopMove;
    }

    private void OnDisable()
    {
        _enemyAttack.OnCollision -= StopMove;
    }
}
