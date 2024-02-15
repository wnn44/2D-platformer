using UnityEngine;
using UnityEngine.Events;

public class EnemyRun : MonoBehaviour
{
    public UnityEvent HitEvent;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerType>())
        {
            HitEvent?.Invoke();
        }
    }
}
