using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using YG;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _buttons;

    private void OnEnable() => YandexGame.GetDataEvent += ChangeOpenLevels;

    private void OnDisable() => YandexGame.GetDataEvent -= ChangeOpenLevels;

    private void Awake()
    {
        if (YandexGame.SDKEnabled == true)
        {
            ChangeOpenLevels();
            SetDefaultOpenLevels();
        }
    }

    private void SetDefaultOpenLevels()
    {
        YandexGame.savesData.openLevels[0] = true;
        YandexGame.savesData.openLevels[1] = true;
    }

    public void ChangeOpenLevels()
    {
        SetDefaultOpenLevels();

        for (int i = 0; i <= YandexGame.savesData.openLevels.Length - 1; i++)
        {
            if (YandexGame.savesData.openLevels[i] == false)
            {
                _buttons[i].SetActive(false);
            }
        }
    }

    public void ResetProgress()
    {
        YandexGame.ResetSaveProgress();
        SetDefaultOpenLevels();
        YandexGame.SaveProgress();
    }

    public void LoadLevel(int index)
    {
        SceneManager.LoadScene(index);
    }
}
