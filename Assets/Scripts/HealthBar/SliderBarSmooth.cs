using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SliderBarSmooth : Bar
{
    [SerializeField] private Slider _slider;

    private float _curentHealth;

    public override void Display()
    {
        StartCoroutine(BarSmooth());
    }

    private void Start()
    {
        Display();
    }

    private IEnumerator BarSmooth()
    {   
        WaitForSeconds waitForSeconds = new WaitForSeconds(Time.deltaTime);

        _curentHealth = Health.CurentValue / Health.MaxValue;

        while (_slider.value != _curentHealth)
        {
            yield return waitForSeconds;

            _slider.value = Mathf.MoveTowards(_slider.value, _curentHealth, Time.deltaTime);
        }
    }
}
