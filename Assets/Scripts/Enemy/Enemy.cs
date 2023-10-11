using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _attackDistance;
    [SerializeField] private int _damage;
    [SerializeField] private float _delay;
    [SerializeField] private Lightning _lightning;

    private Player _target;
    private float _lastAttackTime;
    private bool _isAttacking;

    private void Start()
    {
        _target = FindObjectOfType<Player>();
        _lightning = FindObjectOfType<Lightning>();
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, _target.transform.position) <= _attackDistance)
        {
            if (_lastAttackTime <= 0)
            {
                _isAttacking = true;
                Attack(_target);
                _lastAttackTime = _delay;
            }

            _isAttacking = false;
        }

        _lastAttackTime -= Time.deltaTime;
    }

    private void Attack(Player target)
    {
        target.ApplyDamage(_damage);
        _lightning.transform.up = _target.transform.position * -1 + _lightning.transform.position;
        _lightning.Strike(_isAttacking);       
    }
}
