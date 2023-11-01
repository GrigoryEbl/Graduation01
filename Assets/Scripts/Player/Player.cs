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
    [SerializeField] private FinalTrigger _finalTrigger;
    [SerializeField] private GameObject _legs;
    [SerializeField] private PassedScreen _passedScreen;

    private MoverForPC _moverForPC;
    private int _countCollectibles = 0;

    public int CountCollectibles => _countCollectibles;

    public int CountItems => _countCollectibles;

    public event UnityAction<int> HealthChanged;
    public event UnityAction Died;
    public event UnityAction Collect;

    private void Start()
    {
        HealthChanged?.Invoke(_health);
        _moverForPC = GetComponent<MoverForPC>();
        _showerCountItems = FindObjectOfType<ShowerCurrentNumberItems>();
        _finalTrigger = FindObjectOfType<FinalTrigger>();
        _passedScreen = FindObjectOfType<PassedScreen>();

        _showerCountItems.ShowCountItems(_countCollectibles);
        _legs.SetActive(false);
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
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<CollectedItem>(out CollectedItem collectedItem))
        {
            _countCollectibles += 1;
            _showerCountItems.ShowCountItems(_countCollectibles);
            collectedItem.Collect();
            Collect?.Invoke();
        }
    }

    private void OnEnable()
    {
        _finalTrigger.Final += Modify;
    }

    private void OnDisable()
    {
        _finalTrigger.Final -= Modify;
    }

    private void Modify()
    {
        _moverForPC.enabled = false;
        _legs.SetActive(true);
    }
}
