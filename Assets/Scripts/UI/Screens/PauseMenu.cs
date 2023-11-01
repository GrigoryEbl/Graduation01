using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _panel;

    public void OpenPanel()
    {
        _panel.SetActive(true);
        Time.timeScale = 0;
    }

    public void ClosePanel()
    {
        _panel.SetActive(false);
        Time.timeScale = 1;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;
    }

    public void Exit()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1.0f;
    }
}
