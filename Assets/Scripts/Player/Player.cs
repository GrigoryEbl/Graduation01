using ControllForPC;
using ControllForPhone;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private ShowerCurrentNumberItems _showerCountItems;

    private MoverForPC _moverForPC;
    private MoverForPhones _moverForPhones;
    private int _countItems = 0;

    public int CountItems => _countItems;

    public event UnityAction<int> HealthChanged;
    public event UnityAction Died;
    public event UnityAction Collect;

    private void Start()
    {
        HealthChanged?.Invoke(_health);
        _moverForPC = GetComponent<MoverForPC>();
        _moverForPhones = GetComponent<MoverForPhones>();
        _showerCountItems = FindObjectOfType<ShowerCurrentNumberItems>();

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
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<CollectedItem>(out CollectedItem collectedItem))
        {
            _countItems += 1;
            _showerCountItems.ShowCountItems(_countItems);
            collectedItem.Collect();
            Collect?.Invoke();
        }
    }
}
