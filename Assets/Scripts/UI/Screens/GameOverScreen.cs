using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private GameObject _panel;

    public void OpenPanel()
    {
        _panel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ClosePanel()
    {
        _panel?.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;
        _panel.SetActive(false);
    }

    public void Exit()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1.0f;
    }
}
