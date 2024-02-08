using System;
using UnityEngine;

public class EnemyDetectionPlayer : MonoBehaviour
{
    [SerializeField] private PlayerType _player;

    public static event Action<bool> Detected;

    private SpriteRenderer _enemySprite;

    private void Start()
    {
        _enemySprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
            Detected?.Invoke(Detection());
    }

    private bool Detection()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position + Vector3.up * 0.5f, _player.transform.position + Vector3.up * 0.5f - transform.position);
        Debug.DrawRay(transform.position + Vector3.up * 0.5f, _player.transform.position + Vector3.up * 0.5f - transform.position, Color.red);

        if (hit.collider != null && hit.collider.gameObject == _player.gameObject)
        {
            if (transform.position.x < (_player.transform.position).x && _enemySprite.flipX) return true;
            if (transform.position.x > (_player.transform.position).x && !_enemySprite.flipX) return true;
        }
        return false;
    }
}
