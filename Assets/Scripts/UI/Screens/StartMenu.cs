using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    //private void Awake()
    //{
    //    gameObject.SetActive(true);
    //    Time.timeScale = 0f;
    //}

    public void StartGameButton()
    {
        //gameObject.SetActive(false);
        //Time.timeScale = 1.0f;
        SceneManager.LoadScene(1);
    }
}
