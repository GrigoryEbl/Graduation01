using ControllForPC;
using ControllForPhone;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;

    private MoverForPC _moverForPC;
    private MoverForPhones _moverForPhones;

    public event UnityAction<int> HealthChanged;
    public event UnityAction Died;

    private void Start()
    {
        HealthChanged?.Invoke(_health);
        _moverForPC = GetComponent<MoverForPC>();
        _moverForPhones = GetComponent<MoverForPhones>();
    }

    public void ApplyDamage(int damage)
    {
        _health -= damage;
        HealthChanged?.Invoke(_health);

        if (_health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Died?.Invoke();

        _moverForPC.enabled = false;
        _moverForPhones.enabled = false;
    }
}
