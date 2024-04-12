using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private float _baseSpeed;
    [SerializeField] private LayerMask _platformLayer;
    [SerializeField] private GameObject _sprite;

    private Player _player;
    private float _angleRotationY = 180;
    private float _speed;

    public Vector3 Direction { get; private set; }

    private void Start()
    {
        Direction = transform.right;

        _player = GameObject.FindObjectOfType<Player>();

        _speed = _baseSpeed;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Update()
    {
        DetectionPlayer();
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

    private void DetectionPlayer()
    {
        float coordinateOffset = 0.5f;

        Vector2 origin = transform.position;
        Vector2 direction = _player.transform.position + Vector3.up * coordinateOffset - transform.position;

        RaycastHit2D hit = Physics2D.Raycast(origin, direction);

        Debug.DrawLine(origin, _player.transform.position + Vector3.up * coordinateOffset, Color.red);

        if (hit.collider != null && hit.collider.gameObject == _player.gameObject)
        {
            float angleRotationY = Mathf.Round(transform.rotation.eulerAngles.y);

            if (transform.position.x < (_player.transform.position).x && angleRotationY == _angleRotationY)
            {
                ChangeDirection();
            }

            if (transform.position.x > (_player.transform.position).x && angleRotationY == 0)
            {
                ChangeDirection();
            }
        }
    }

    public void StopMove()
    {
        float minSpeed = 0.01f;

        _speed = minSpeed;
    }

    public void StartMove()
    {
        _speed = _baseSpeed;
    }
}
