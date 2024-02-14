using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private LayerMask _platformLayer;
    [SerializeField] private PlayerType _player;

    public Vector3 Direction { get; private set; }


    private bool _isEndOfRoad;
    private SpriteRenderer _enemySprite;

    private void Start()
    {
        Direction = transform.right;
        _enemySprite = GetComponentInChildren<SpriteRenderer>();
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
        float distanceHorizont = 0.5f;
        
        RaycastHit2D hit = Physics2D.Raycast(transform.position + Direction * offset, Vector3.down, distanceDown, _platformLayer);
        RaycastHit2D hitRight = Physics2D.Raycast(transform.position, Vector3.right, distanceHorizont, _platformLayer);
        RaycastHit2D hitLeft = Physics2D.Raycast(transform.position, Vector3.left, distanceHorizont, _platformLayer);

        _isEndOfRoad = (hit.collider != null && hitRight.collider == null && hitLeft.collider == null);

        return _isEndOfRoad;
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
        Direction *= -1.0f;
        _enemySprite.flipX = Direction.x < 0;
    }

    private void DetectionPlayer()
    {
        float coordinateOffset = 0.5f;

        RaycastHit2D hit = Physics2D.Raycast(transform.position + Vector3.up * coordinateOffset, _player.transform.position + Vector3.up * coordinateOffset - transform.position);

        if (hit.collider != null && hit.collider.gameObject == _player.gameObject)
        {
            if (transform.position.x < (_player.transform.position).x && _enemySprite.flipX) ChangeDirection();
            if (transform.position.x > (_player.transform.position).x && !_enemySprite.flipX) ChangeDirection();
        }
    }
}
