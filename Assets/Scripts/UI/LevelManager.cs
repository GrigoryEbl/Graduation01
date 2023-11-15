using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using YG;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Button[] _buttons;

    private void Start()
    {
        _buttons = GetComponentsInChildren<Button>();
        print("Open levels: " + YandexGame.savesData.openLevels.Length);
        ChangeOpenLevels();
    }

    private void ChangeOpenLevels()
    {
        for (int i = YandexGame.savesData.openLevels.Length - 1; i <= 0 ; i--)
        {
                _buttons[i].interactable = false;
            print("interactable = false");
            _buttons[i].enabled = false;
            print("enabled = false");
                _buttons[i].image.color = Color.black;
            //if (YandexGame.savesData.openLevels[i] == false)
            //{
            //}
        }
    }

    public void LoadLevel(int index)
    {
        SceneManager.LoadScene(index);
    }
}
