using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Heart : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private States State
    {
        get { return (States)_animator.GetInteger("State"); }
        set { _animator.SetInteger("State", (int)value); }
    }

    public void Fill()
    {
        State = States.fill;
    }

    public void Destroy()
    {
        State = States.destroy;
    }

    public enum States
    {
        fill,
        destroy
    }
}
