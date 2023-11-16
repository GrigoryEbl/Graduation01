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
        for (int i = YandexGame.savesData.openLevels.Length - 1; i >= 0; i--)
        {
            if (YandexGame.savesData.openLevels[i] == true)
            {
                SceneManager.LoadScene(i);
                break;
            }
        }
    }
}
