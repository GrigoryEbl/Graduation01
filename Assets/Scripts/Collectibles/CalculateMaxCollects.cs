using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CalculateMaxCollects : MonoBehaviour
{
    public int MaxCount { get; private set; }

    private void Awake()
    {
        MaxCount = transform.childCount;
    }
}
