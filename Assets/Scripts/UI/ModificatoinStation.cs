using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModificatoinStation : MonoBehaviour
{
    [SerializeField] private BoxCollider2D _finalTrigger;
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _particleSystem = GetComponent<ParticleSystem>();
        _finalTrigger = GetComponentInChildren<BoxCollider2D>();

        _particleSystem.Stop();
        _finalTrigger.enabled = false;
    }

    public void Activate()
    {
        _particleSystem.Play();
        _finalTrigger.enabled = true;
        _animator.Play("Flicker");
    }
}
