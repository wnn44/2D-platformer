using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private LayerMask _platformLayer;

    [SerializeField] private PlayerType _player;

    private Vector3 _direction;
    private bool _isEndOfRoad;
    private SpriteRenderer _enemySprite;

    private void Start()
    {
        _direction = transform.right;
        _enemySprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        // MoveEnemy();
        Move();
    }

    private void MoveEnemy()
    {
        if (!CheckingEndOfPath())
        {
            _direction *= -1.0f;
            _enemySprite.flipX = _direction.x < 0;
        }
        transform.position = Vector3.MoveTowards(transform.position, transform.position + _direction, _speed * Time.deltaTime);
    }

    private bool CheckingEndOfPath()
    {
        float offset = 0.3f;

        RaycastHit2D hit = Physics2D.Raycast(transform.position + _direction * offset, Vector3.down, 1f, _platformLayer);
        RaycastHit2D hit1 = Physics2D.Raycast(transform.position + _direction, Vector3.left, 0f, _platformLayer);

        _isEndOfRoad = (hit.collider != null && hit1.collider == null);

        return _isEndOfRoad;
    }

    private void Move()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position + Vector3.up * 0.5f, _player.transform.position + Vector3.up * 0.5f - transform.position);

        //Debug.DrawRay(transform.position + Vector3.up * 0.5f, _player.transform.position + Vector3.up * 0.5f - transform.position, Color.red);

        if (!CheckingEndOfPath())
        {
            ChangeDirection();
        }

        if (hit.collider != null)
        {
            if (hit.collider.gameObject != _player.gameObject)
            {
                transform.position = Vector3.MoveTowards(transform.position, transform.position + _direction, _speed * Time.deltaTime);
            }
            else
            {
                if (transform.position.x < (_player.transform.position + _direction).x && _enemySprite.flipX) ChangeDirection();

                if (transform.position.x > (_player.transform.position + _direction).x && !_enemySprite.flipX) ChangeDirection();

                transform.position = Vector3.MoveTowards(transform.position, _player.transform.position + _direction, _speed * Time.deltaTime);
            }
        }
    }

    private void ChangeDirection()
    {
        _direction *= -1.0f;
        _enemySprite.flipX = _direction.x < 0;
    }
}
