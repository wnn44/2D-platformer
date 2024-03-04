using System;
using UnityEngine;
using UnityEngine.Events;

public class EnemyAttack : MonoBehaviour
{
    //public UnityEvent HitEvent;
    public static event Action OnAttack;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            //HitEvent?.Invoke();
            OnAttack?.Invoke();
        }
    }
}
