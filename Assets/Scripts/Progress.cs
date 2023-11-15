using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;

public class Progress : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    public static Progress Instance;
    public int PassedLevels;

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
        _text.text = PassedLevels.ToString();
    }
}
