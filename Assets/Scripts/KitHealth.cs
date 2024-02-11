using UnityEngine;
using System;

public class KitHealth : MonoBehaviour
{
    [SerializeField] private int _healValue;

    public static event Action<int> KitHealthFound;
    public static event Action KitHealthAdd;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerType playerType))
        {
            KitHealthFound?.Invoke(_healValue);
            KitHealthAdd?.Invoke();

            Destroy(gameObject);
        }
    }
}
