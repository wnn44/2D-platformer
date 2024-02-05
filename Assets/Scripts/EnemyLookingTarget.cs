using System.Collections;
using UnityEngine;

public class EnemyLookingTarget : MonoBehaviour
{
    [SerializeField] private PlayerType _player;

    private void Update()
    {
        CheckPlayerVisibil();

    }

    private bool CheckPlayerVisibil()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position + Vector3.up * 0.5f, _player.transform.position + Vector3.up * 0.5f - transform.position);

        Debug.DrawRay(transform.position + Vector3.up * 0.5f, _player.transform.position + Vector3.up * 0.5f - transform.position, Color.red);

        if (hit.collider != null)
        {
            if (hit.collider.gameObject != _player.gameObject)
            {
                Debug.Log("Путь к игроку преграждает объект: " + hit.collider.name);
            }
            else
            {
                Debug.Log("Вижу игрока!!!");
            }
        }

        return hit.collider != null;
    }
}
