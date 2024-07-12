using System;
using UnityEngine;

[RequireComponent(typeof(EnemyMove))]
public class PlayerSearch : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _distance;

    public event Action<bool> OnPlayer;

    private EnemyMove _enemyMove;

    private void Awake()
    {
        _player = GameObject.FindObjectOfType<Player>();
        _enemyMove = GetComponent<EnemyMove>();
    }

    private void FixedUpdate()
    {
        DetectPlayer();
    }

    private void DetectPlayer()
    {
        Vector2 ray = transform.position;
        Vector2 direction = transform.TransformDirection(_enemyMove.Direction);

        RaycastHit2D hit = Physics2D.Raycast(ray, direction, _distance);

        Debug.DrawRay(ray, direction * _distance, Color.red);

        OnPlayer?.Invoke(hit.collider != null && hit.collider.gameObject == _player.gameObject);
    }
}
