using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using YG;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Button[] _buttons;

    private void OnEnable() => YandexGame.GetDataEvent += ChangeOpenLevels;

    private void OnDisable() => YandexGame.GetDataEvent -= ChangeOpenLevels;

    private void Awake()
    {
        _buttons = GetComponents<Button>();

        print("Open levels: " + YandexGame.savesData.openLevels.Length +
            "\nlvl0: " + YandexGame.savesData.openLevels[0] +
            "\nlvl1: " + YandexGame.savesData.openLevels[1] +
            "\nlvl2: " + YandexGame.savesData.openLevels[2]);

        if (YandexGame.SDKEnabled == true)
        {
            print("SDKEnabled");

            
            ChangeOpenLevels();
        }
    }

    private void SetOpenLevels()
    {
        YandexGame.savesData.openLevels[0] = true;
        YandexGame.savesData.openLevels[1] = true;
        YandexGame.savesData.openLevels[2] = false;
    }

    public void ChangeOpenLevels()
    {
        SetOpenLevels();
        print("SDKEnabled1");

        for (int i = YandexGame.savesData.openLevels.Length - 1; i >= 0; i--)
        {
            print("SDKEnabled2");

            if (YandexGame.savesData.openLevels[i] == false)
            {
                print("SDKEnabled3");
                _buttons[i].image.color = Color.black;
                _buttons[i].interactable = false;
            }
        }
    }

    public void RemoveProgress()
    {
        YandexGame.ResetSaveProgress();
        SetOpenLevels();
        YandexGame.LoadProgress();
        YandexGame.SaveProgress();
    }

    public void LoadLevel(int index)
    {
        SceneManager.LoadScene(index);
    }
}
