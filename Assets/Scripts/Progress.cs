using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using YG;

public class Progress : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    public static Progress Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            transform.parent = null;
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        _text.text = "level 1: " + YandexGame.savesData.openLevels[1].ToString() +
                     "\nlevel 2: " + YandexGame.savesData.openLevels[2].ToString();
        
    }
}
