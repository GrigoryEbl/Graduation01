using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;


public class PassedScreen : MonoBehaviour
{
    [SerializeField] private GameObject _passedPanel;
    [SerializeField] private CalculateScores _calculateScores;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private GameObject _healthBar;
    [SerializeField] private GameObject _openPauseMenuButton;
    [SerializeField] private GameObject _showCollectIblesPanel;

    private int _score;

    private void Start()
    {
        _calculateScores = FindObjectOfType<CalculateScores>();
    }

    public void Activate()
    {
        Progress.Instance.PassedLevels = + 1;

        _passedPanel.SetActive(true);
        _healthBar.SetActive(false);
        _openPauseMenuButton.SetActive(false);
        _showCollectIblesPanel.SetActive(false);
        _score = _calculateScores.Calculate();

        _text.text = "Score: " + _score.ToString();
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ReturnHome()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1.0f;
    }
}
