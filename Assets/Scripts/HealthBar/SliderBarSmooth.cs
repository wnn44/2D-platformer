using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SliderBarSmooth : Bar
{
    [SerializeField] private Slider _slider;
    [SerializeField] private float _maxDelta;

    private float _curentHealth;

    private void Start()
    {
        Display();
    }

    public override void Display()
    {
        StartCoroutine(wait());
    }

    IEnumerator wait()
    {
        _curentHealth = Health.CurentValue / Health.MaxValue;

        while (_slider.value != _curentHealth)
        {
            yield return new WaitForSeconds(_maxDelta);

            _slider.value = Mathf.MoveTowards(_slider.value, _curentHealth, _maxDelta);
        }
    }
}
