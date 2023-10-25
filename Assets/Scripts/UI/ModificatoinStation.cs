using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModificatoinStation : MonoBehaviour
{
    private Animator _animator;
    private ParticleSystem _particleSystem;
   

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _particleSystem = GetComponent<ParticleSystem>();
       
        _animator.enabled = false;
        _particleSystem.Stop();
    }

    public void Activate()
    {
        _animator.enabled = true;
        _particleSystem.Play();
    }
}
