using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class Vampirism : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _chargeVampirizm;

    public GameObject Sprite;

    private Health _playerHealth;
    private float _timeAction = 6.0f;
    private float _timeCharge = 4.0f;
    private int _damage = 1;
    private bool _abilityActive = true;
    private bool _damageActivity = false;

    private void OnEnable()
    {
        MovementState.ActionVampirism += ActiveVampirizm;
    }

    private void OnDisable()
    {
        MovementState.ActionVampirism -= ActiveVampirizm;
    }

    private void Start()
    {
        _playerHealth = GetComponent<Health>();
    }

    public void ActiveVampirizm()
    {
        if (_abilityActive)
        {
            Sprite.SetActive(true);

            _abilityActive = false;
            _damageActivity = true;

            StartCoroutine(StartVampirism());
        }
    }

    public IEnumerator StartVampirism()
    {
        float elapsedTime = 0f;

        while (elapsedTime < _timeAction)
        {
            yield return null;
            elapsedTime += Time.deltaTime;

            ViewCharge(elapsedTime, _timeAction);
        }

        StopVampirism();
    }

    public IEnumerator ChargeVampirism()
    {
        float elapsedTime = 0f;

        while (elapsedTime < _timeCharge)
        {
            yield return null;
            elapsedTime += Time.deltaTime;

            ViewCharge(_timeCharge - elapsedTime, _timeCharge);
        }

        _abilityActive = true;
    }

    private void StopVampirism()
    {
        Sprite.SetActive(false);

        _damageActivity = false;

        StartCoroutine(ChargeVampirism());
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy) & _damageActivity)
        {
            enemy.Damage(_damage);
            _playerHealth.TakeHeal(_damage);
        }
    }

    private void ViewCharge(float elapsedTime, float fullTime)
    {
        _chargeVampirizm.text = "V " + Math.Round((fullTime - elapsedTime) / (fullTime / 100)) + "%";
    }
}
