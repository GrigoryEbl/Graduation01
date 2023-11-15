using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using YG;

public class StartMenu : MonoBehaviour
{
    private void OnEnable() => YandexGame.GetDataEvent += GetData;

    private void OnDisable() => YandexGame.GetDataEvent -= GetData;

    private void Awake()
    {
        if (YandexGame.SDKEnabled == true)
            GetData();
    }

    public void GetData()
    {
        YandexGame.savesData.openLevels[0] = true;
        YandexGame.savesData.openLevels[1] = true;
        YandexGame.SaveProgress();
    }

    public void PlayGame()
    {
        for (int i = YandexGame.savesData.openLevels.Length - 1; i >= 0; i--)
        {
            if (YandexGame.savesData.openLevels[i] == true)
            {
                SceneManager.LoadScene(Convert.ToInt32( YandexGame.savesData.openLevels[i]));
                break;
            }
        }
    }
}
