using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FinalTrigger : MonoBehaviour
{
    [SerializeField] private GameObject _canvas;

    private Animator _animator;

    public event UnityAction Final;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            Final?.Invoke();
            _canvas.SetActive(false);
            _animator.enabled = true;
        }
    }
}
