using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using YG;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _buttons;

    private void Start()
    {
        if (YandexGame.SDKEnabled)
        {
            ChangeOpenedLevels();
        }
    }

    private void OnEnable()
    {
        YandexGame.GetDataEvent += ChangeOpenedLevels;
    }

    private void OnDisable()
    {
        YandexGame.GetDataEvent -= ChangeOpenedLevels;
    }

    public void ResetProgress()
    {
        YandexGame.ResetSaveProgress();
        ChangeOpenedLevels();
        YandexGame.SaveProgress();
    }

    public void ChangeOpenedLevels()
    {
        for (int i = 0; i < YandexGame.savesData.OpenedLevels.Length; i++)
        {
            if (YandexGame.savesData.OpenedLevels[i] == true)
            {
                _buttons[i].SetActive(true);
            }
            else
            {
                _buttons[i].SetActive(false);
            }
        }
    }

    public void LoadSelectedLevel(int number)
    {
        SceneManager.LoadScene(number);
    }
}
