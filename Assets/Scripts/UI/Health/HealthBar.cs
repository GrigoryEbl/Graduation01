using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Heart _heartTemplate;

    private List<Heart> _hearts = new List<Heart>();

    private void OnEnable()
    {
        _player.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(int value)
    {
        if (_hearts.Count < value)
        {
            int createHealth = value - _hearts.Count;

            for (int i = 0; i < createHealth; i++)
            {
                CreateHeart();
            }
        }
        else if (_hearts.Count > value && _hearts.Count != 0)
        {
            int deleteHealth = _hearts.Count - value;

            for (int i = 0; i < deleteHealth; i++)
            {
                DestroyHeart(_hearts[_hearts.Count - 1]); //_hearts[_hearts.Count - 1]
            }
        }
    }

    private void DestroyHeart(Heart heart)
    {
        heart.Destroy();
        _hearts.Remove(heart);
    }

    private void CreateHeart()
    {
        Heart newHeart = Instantiate(_heartTemplate, transform);
        newHeart.Fill();
        _hearts.Add(newHeart.GetComponent<Heart>());
    }
}
