using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowerCurrentNumberItems : MonoBehaviour
{
    [SerializeField] private TMP_Text _currentNumberItems;
    [SerializeField] private CalculateMaxCollects _calculateCollects;

    private void Awake()
    {
        _calculateCollects = FindObjectOfType<CalculateMaxCollects>();
        _currentNumberItems = GetComponentInChildren<TMP_Text>();
    }

    public void ShowCountItems(int count)
    {
        _currentNumberItems.text = count.ToString() + " / " + _calculateCollects.MaxCount;
    }
}
