using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CalculateScores : MonoBehaviour
{
    [SerializeField] private Timer _timer;
    [SerializeField] private Player _countCollectibles;

    private int _score;
    private int _maxScore = 500;
    private int _minScore = 100;

    private void Awake()
    {
        _timer = GetComponent<Timer>();
        _countCollectibles = FindObjectOfType<Player>();
    }

    public int Calculate()
    {
        _timer.PauseTimer();
        int time = Convert.ToInt32(_timer.TimeSecond);

        if (_countCollectibles.CountCollectibles != 0)
            _score = _maxScore - (time / _countCollectibles.CountCollectibles);
        else
            _score = _minScore;

        return _score;
    }
}
