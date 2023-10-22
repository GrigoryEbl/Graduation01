using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaDamage : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _delay;

    private float _lastDamageTime;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            if (_lastDamageTime <= 0)
            {
                player.ApplyDamage(_damage);
                _lastDamageTime = _delay;
            }

            _lastDamageTime -= Time.deltaTime;
        }
    }
}
