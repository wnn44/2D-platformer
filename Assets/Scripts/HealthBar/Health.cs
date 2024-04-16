using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxValue;
    [SerializeField] private int _curentValue;

    public event Action Changed;
    public event Action Died;

    public float MaxValue => _maxValue;
    public float CurentValue => _curentValue;

    private void CurrentValueChanged()
    {
        _curentValue = Mathf.Clamp(_curentValue, 0, _maxValue);

        Changed?.Invoke();
        
        if (_curentValue == 0)
        {
            Died?.Invoke();
        }
    }

    public void TakeDamage(int damageValue)
    {
        if (damageValue > 0)
            _curentValue -= damageValue;

        CurrentValueChanged();
    }

    public void TakeHeal(int healValue)
    {
        if (healValue > 0)
            _curentValue += healValue;

        CurrentValueChanged();
    }
}
