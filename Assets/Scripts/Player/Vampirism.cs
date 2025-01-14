using System.Collections;
using UnityEngine;

public class Vampirism : MonoBehaviour
{
    public GameObject Sprite;

    private Health _playerHealth;
    private float _timeAction = 6.0f;
    //private float _timeCharge = 4.0f;
    private int _damageEnemy = 1;
    private bool _abilityActive = false;

    void Start()
    {
        _playerHealth = GetComponent<Health>();
    }

    public void ViewSprite()
    {
        Sprite.SetActive(true);

        StartCoroutine(StartVampirism());
    }

    public IEnumerator StartVampirism()
    {
        float elapsedTime = 0f;

        while (elapsedTime < _timeAction)
        {
            yield return null;
            elapsedTime += Time.deltaTime;

            ActionVampirism();
        }

        StopVampirism();
    }

    private void StopVampirism()
    {
        Sprite.SetActive(false);

        _abilityActive = false;
    }

    private void ActionVampirism()
    {
        _abilityActive = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy) & _abilityActive)
        {
            enemy.Damage(_damageEnemy);
            _playerHealth.TakeHeal(_damageEnemy);
        }
    }
}
