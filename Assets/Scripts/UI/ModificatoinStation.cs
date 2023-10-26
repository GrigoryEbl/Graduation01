using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModificatoinStation : MonoBehaviour
{
    private Animator _animator;
    private ParticleSystem _particleSystem;
    private FinalTrigger _finalTrigger;
   

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _particleSystem = GetComponent<ParticleSystem>();
        _finalTrigger = GetComponentInChildren<FinalTrigger>(); 
       
        _particleSystem.Stop();
        _finalTrigger.enabled = false;
    }

    public void Activate()
    {
        _animator.Play("Flicker");
        _particleSystem.Play();
        _finalTrigger.enabled = true;
    }
}
