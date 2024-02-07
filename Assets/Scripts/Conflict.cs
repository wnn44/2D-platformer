using System;
using UnityEngine;

public class Conflict : MonoBehaviour
{
    [SerializeField] private EnemyType _enemy;

    const int AttackState = 3;

    public static event Action<int> StateValue;

    private void Update()
    {
        —hecking—ontact();
    }

    private void —hecking—ontact()
    {
        if(transform.position.x - _enemy.transform.position.x < 0.8f)
        {
           // Debug.Log(transform.position.x - _enemy.transform.position.x);
            StateValue?.Invoke(AttackState);
        }        
    }
}
