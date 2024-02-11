using UnityEngine;
using UnityEngine.Events;

public class EnemyRun : MonoBehaviour
{
    [SerializeField] private PlayerType _player;

    public UnityEvent HitEvent;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == _player.name)
        {
            HitEvent?.Invoke();
        }
    }
}
