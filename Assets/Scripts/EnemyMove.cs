using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private LayerMask _platformLayer;
    [SerializeField] private PlayerType _player;

    public Vector3 Direction { get; private set;}


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

        RaycastHit2D hit = Physics2D.Raycast(transform.position + Direction * offset, Vector3.down, 1f, _platformLayer);
        RaycastHit2D hit1 = Physics2D.Raycast(transform.position + Direction, Vector3.left, 0f, _platformLayer);

        _isEndOfRoad = (hit.collider != null && hit1.collider == null);

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
        RaycastHit2D hit = Physics2D.Raycast(transform.position + Vector3.up * 0.5f, _player.transform.position + Vector3.up * 0.5f - transform.position);
        //Debug.DrawRay(transform.position + Vector3.up * 0.5f, _player.transform.position + Vector3.up * 0.5f - transform.position, Color.red);

        if (hit.collider != null && hit.collider.gameObject == _player.gameObject)
        {
            if (transform.position.x < (_player.transform.position).x && _enemySprite.flipX) ChangeDirection();
            if (transform.position.x > (_player.transform.position).x && !_enemySprite.flipX) ChangeDirection();
        }
    }
}
