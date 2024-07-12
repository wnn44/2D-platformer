using System;
using UnityEngine;

[RequireComponent(typeof(EnemyAnimations))]
public class EnemyAttack : MonoBehaviour
{
   [SerializeField] private int _damage = 1 ;

    public event Action<int> Attack;
    public event Action Collision;

    private EnemyAnimations _enemyAnimations;

    private void Start()
    {
        _enemyAnimations = GetComponent<EnemyAnimations>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            Attack?.Invoke(_damage);

            _enemyAnimations.Attack();

            Collision?.Invoke();
        }
    }
}
