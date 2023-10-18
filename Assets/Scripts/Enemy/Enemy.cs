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

    private void Start()
    {
        _target = FindObjectOfType<Player>();
        _lightning = GetComponentInChildren<Lightning>();
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, _target.transform.position) <= _attackDistance)
        {
            if (_lastAttackTime <= 0)
            {
                Attack(_target);
                _lastAttackTime = _delay;
            }
        }

        _lastAttackTime -= Time.deltaTime;
    }

    private void Attack(Player target)
    {
        _lightning.Strike();

        target.ApplyDamage(_damage);

        _lightning.transform.up = _target.transform.position * -1 + _lightning.transform.position;
    }
}
