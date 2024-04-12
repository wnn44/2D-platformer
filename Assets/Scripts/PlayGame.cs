using UnityEngine;

public class PlayGame : MonoBehaviour
{
    public GameObject Panel;

    public void Play()
    {
        Panel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Pause()
    {
        Panel.SetActive(true);
        Time.timeScale = 0f;
    }
}