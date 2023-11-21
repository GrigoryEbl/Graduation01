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

    private void OnEnable() => YandexGame.GetDataEvent += LoadGame;

    private void OnDisable() => YandexGame.GetDataEvent -= LoadGame;

    private void Start()
    {
        if(YandexGame.SDKEnabled)
        {
            LoadGame();
        }
    }

    private void SetDefaultOpenLevels()
    {
        for (int i = 0; i <= YandexGame.savesData.openLevels.Length - 1; i++)
        {
            YandexGame.savesData.openLevels[i] = false;
        }

        YandexGame.savesData.openLevels[0] = true;
        YandexGame.savesData.openLevels[1] = true;
    }

    public void ChangeOpenedLevels()
    {
        for (int i = 0; i <= YandexGame.savesData.openLevels.Length - 1; i++)
        {
            if (YandexGame.savesData.openLevels[i] == true)
            {
                _buttons[i].SetActive(true);
            }
        }
    }

    public void ResetProgress()
    {
        YandexGame.ResetSaveProgress();
        SetDefaultOpenLevels();
        ChangeOpenedLevels();
        YandexGame.SaveProgress();
    }

    private void LoadGame()
    {
        ChangeOpenedLevels();

        if (YandexGame.savesData.isFirstSession)
        {
            ResetProgress();
            ChangeOpenedLevels();
        }
    }
}
