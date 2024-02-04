using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private LayerMask _platformLayer;

    private Vector3 _direction;
    private bool _isGrounded;
    private SpriteRenderer _enemySprite;

    private void Start()
    {
        _direction = transform.right;
        _enemySprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        MoveEnemy();
    }

    private void MoveEnemy()
    {
        if (!CheckGround())
        {
            _direction *= -1.0f;
            _enemySprite.flipX = _direction.x < 0;
        }
        transform.position = Vector3.MoveTowards(transform.position, transform.position + _direction, _speed * Time.deltaTime);
    }

    private bool CheckGround()
    {
        float offset = 0.4f;

        RaycastHit2D hit = Physics2D.Raycast(transform.position + _direction * offset, Vector3.down, 1, _platformLayer);
        RaycastHit2D hit1 = Physics2D.Raycast(transform.position + _direction, Vector3.left, 0, _platformLayer);

        _isGrounded = (hit.collider != null && hit1.collider == null);

        return _isGrounded;
    }
}
