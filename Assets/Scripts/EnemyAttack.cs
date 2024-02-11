﻿using UnityEngine;
using UnityEngine.Events;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private PlayerType _player;

    public UnityEvent HitEvent;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name == _player.name)
        {
            HitEvent?.Invoke();
        }
    }
}
