using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CalculareCollets : MonoBehaviour
{
    [SerializeField] private CollectItems _collectItems;

    [SerializeField] private TMP_Text _text;

    public int MaxCount;
    public int CurrCount;

    private void OnEnable()
    {
        _collectItems.Destroid += OnCollectChange;
    }

    private void OnDisable()
    {
        _collectItems.Destroid -= OnCollectChange;
    }

    private void OnCollectChange()
    {
        CurrCount += 1;
        _text.text = CurrCount.ToString();
    }
}
