using UnityEngine;

public class KitHealth : MonoBehaviour
{
    [SerializeField] private int _healValue = 20;

    public int HealValue { get { return _healValue; } }
}
