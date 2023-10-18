using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private string _animStrike = "Strike";

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Strike()
    {
        _animator.Play(_animStrike);
    }
}
