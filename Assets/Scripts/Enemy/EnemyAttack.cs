using System;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private int _damage = 1 ;

    public static event Action<int> OnAttack;

    private EnemyAnimations _enemyAnimations;
    private EnemyMove _enemyMove;

    private void Start()
    {
        _enemyAnimations = GetComponent<EnemyAnimations>();
        _enemyMove = GetComponent<EnemyMove>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            OnAttack?.Invoke(_damage);

            _enemyAnimations.Attack();

            _enemyMove.StopMove();
        }
    }
}
