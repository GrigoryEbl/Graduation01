using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Strike(bool isAttack)
    {
        if (isAttack) 
        _animator.Play("Strike");
    }
}
