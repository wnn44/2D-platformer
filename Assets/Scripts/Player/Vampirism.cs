using System.Collections;
using UnityEngine;

public class Vampirism : MonoBehaviour
{
    private float _timeAction = 6.0f;
    //private float _timeChange = 4.0f;
    public GameObject Sprite;

    void Start()
    {
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
    }

    private void ActionVampirism()
    {
        Debug.Log("-----");
    }
}
