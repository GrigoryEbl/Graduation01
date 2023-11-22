using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using YG;

public class StartMenu : MonoBehaviour
{
    public void PlayGame()
    {
        for (int i = YandexGame.savesData.OpenedLevels.Length - 1; i >= 0; i--)
        {
            if (YandexGame.savesData.OpenedLevels[i] == true)
            {
                SceneManager.LoadScene(i);
                break;
            }
        }
    }
}
