using System;
using UnityEngine;

[RequireComponent(typeof(EnemyAnimations))]
public class EnemyAttack : MonoBehaviour
{
    private int _damage = 1 ;

    public event Action<int> OnAttack;
    public event Action OnCollision;

    private EnemyAnimations _enemyAnimations;

    private void Start()
    {
        _enemyAnimations = GetComponent<EnemyAnimations>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            OnAttack?.Invoke(_damage);

            _enemyAnimations.Attack();

            OnCollision?.Invoke();
        }
    }
}
