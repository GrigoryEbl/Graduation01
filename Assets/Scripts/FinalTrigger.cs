using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using YG;

public class FinalTrigger : MonoBehaviour
{
    private Animator _animator;

    public event UnityAction Final;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _animator.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            try
            {
                YandexGame.savesData.OpenedLevels[SceneManager.GetActiveScene().buildIndex + 1] = true;
                
            }
            catch
            {
                YandexGame.savesData.OpenedLevels[SceneManager.GetActiveScene().buildIndex] = true;
            }
            finally
            {
                YandexGame.SaveProgress();
                Final?.Invoke();
                _animator.enabled = true;
            }
        }
    }
}
