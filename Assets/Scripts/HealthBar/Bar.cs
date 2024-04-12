using UnityEngine;

[RequireComponent(typeof(Health))]

public class Bar : MonoBehaviour
{
    private Health _health;

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

    public virtual void Display() { }
}
