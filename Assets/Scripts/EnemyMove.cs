using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private LayerMask _platformLayer;
    [SerializeField] private Player _player;

    public Vector3 Direction { get; private set; }

    private float _angleRotationY = 180;

    private void Start()
    {
        Direction = transform.right;
    }

    private void Update()
    {
        Move();

        DetectionPlayer();
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

    private void Move()
    {
        if (!CheckingEndOfPath())
        {
            ChangeDirection();
        }

        transform.position = Vector3.MoveTowards(transform.position, transform.position + Direction, _speed * Time.deltaTime);
    }

    private void ChangeDirection()
    {
        int reverseDirection = -1;
        Direction *= reverseDirection;

        transform.Rotate(0, _angleRotationY, 0);
    }

    private void DetectionPlayer()
    {
        float coordinateOffset = 0.5f;

        Vector2 origin = transform.position + Vector3.up * coordinateOffset;
        Vector2 direction = _player.transform.position + Vector3.up * coordinateOffset - transform.position;

        RaycastHit2D hit = Physics2D.Raycast(origin, direction);

        if (hit.collider != null && hit.collider.gameObject == _player.gameObject)
        {
            float angleRotationY = Mathf.Round(transform.rotation.eulerAngles.y);

            if (transform.position.x < (_player.transform.position).x && angleRotationY == _angleRotationY) ChangeDirection();
            if (transform.position.x > (_player.transform.position).x && angleRotationY == 0) ChangeDirection();
        }
    }
}
