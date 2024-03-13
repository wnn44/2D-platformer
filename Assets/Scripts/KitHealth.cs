using UnityEngine;

public class KitHealth : MonoBehaviour
{
    [SerializeField] private int _healValue = 100;

    public int HealValue { get { return _healValue; } }
}
