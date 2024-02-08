using UnityEngine;
using System;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private PlayerType _player;

    private bool _isAttacking;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == _player.name)
        {
            Debug.Log("Контакт");
            _isAttacking = true;
        }
    }
}
