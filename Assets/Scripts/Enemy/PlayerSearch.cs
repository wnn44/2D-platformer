using UnityEngine;

public class PlayerSearch : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _distance;

    private EnemyMove _enemyMove;

    private void Awake()
    {
        _player = GameObject.FindObjectOfType<Player>();
        _enemyMove = GetComponent<EnemyMove>();
    }

    private void FixedUpdate()
    {
        DetectionPlayer();
    }

    private void DetectionPlayer()
    {
        Vector2 ray = transform.position;
        Vector2 direction = transform.TransformDirection( _enemyMove.Direction);

        RaycastHit2D hit = Physics2D.Raycast(ray, direction, _distance);

        Debug.DrawRay(ray, direction * _distance, Color.red);

        if (hit.collider != null && hit.collider.gameObject == _player.gameObject)
        {
                Debug.Log(hit.collider.gameObject);
        }
    }
}
