using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Health))]

public class Vampirism : MonoBehaviour
{
    [SerializeField] private GameObject Sprite;
    [SerializeField] private Slider _slider;

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

    private void ActiveVampirizm()
    {
        if (_abilityActive)
        {
            Sprite.SetActive(true);

            _abilityActive = false;
            _damageActivity = true;

            StartCoroutine(WorksVampirism());
        }
    }

    private IEnumerator WorksVampirism()
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

    private IEnumerator ChargeVampirism()
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
        if (_damageActivity && collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            if (enemy == FindClosestEnemy())
            {
                enemy.Damage(_damage);
                _playerHealth.TakeHeal(_damage);
            }
        }        
    }

    private void ViewCharge(float elapsedTime, float fullTime)
    {
        _slider.value = ((float)(Math.Round((fullTime - elapsedTime) / (fullTime / 100)))/100);
    }

    private Enemy FindClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

         if (enemies.Length == 0)
        {
            return null;
        }

        Enemy closest;

        if (enemies.Length == 1)
        {
            closest = enemies[0].GetComponent<Enemy>();
            return closest;
        }

        closest = enemies
            .OrderBy(go => (gameObject.transform.position - go.transform.position).sqrMagnitude)
            .First().GetComponent<Enemy>();

        return closest;
    }
}
