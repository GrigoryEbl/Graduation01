using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float _time = 0;
    private bool _isStart = false;

    public float TimeSecond => _time;

    private void Awake()
    {
        StartTimer();
    }

    private void Update()
    {
        if(_isStart)
        {
            _time += Time.deltaTime;
        }
    }

    public void StartTimer()
    {
        _isStart = true;
    }

    public void PauseTimer()
    {
        _isStart = false;
    }

    public void StopTimer()
    {
        _isStart = false;
        _time = 0;
    }
}
