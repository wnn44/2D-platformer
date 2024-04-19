using UnityEngine;

[RequireComponent(typeof(Health))]

public class Bar : MonoBehaviour
{
    private Health _health;

    public virtual void Display() { }

    protected Health Health => _health;

    private void OnEnable()
    {
        _health.Changed += Display;
    }

    private void OnDisable()
    {
        _health.Changed -= Display;
    }

    private void Awake()
    {
        _health = GetComponent<Health>();
    }
}
