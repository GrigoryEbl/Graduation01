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
    }

    public void Restart()
    {
        _panel.SetActive(false);
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
