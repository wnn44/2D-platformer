using UnityEngine;

public class Enemy : MonoBehaviour
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
        MovePlayer();
    }

    private void MovePlayer()
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
        RaycastHit2D hit = Physics2D.Raycast(transform.position + _direction * 0.4f, Vector3.down, 1, _platformLayer);
        RaycastHit2D hit1 = Physics2D.Raycast(transform.position + _direction, Vector3.left, 0, _platformLayer);

        _isGrounded = (hit.collider != null && hit1.collider == null );

        //Debug.DrawRay(transform.position + _direction * 0.4f, Vector3.down);

        return _isGrounded;
    }
}