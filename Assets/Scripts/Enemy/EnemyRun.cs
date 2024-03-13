using UnityEngine;

public class EnemyRun : MonoBehaviour
{
    private EnemyAnimations _enemyAnimations;
    private EnemyMove _enemyMove;

    private void Start()
    {
        _enemyAnimations = GetComponent<EnemyAnimations>();
        _enemyMove = GetComponent<EnemyMove>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            _enemyAnimations.Run();

            _enemyMove.StartMove();
        }
    }
}
