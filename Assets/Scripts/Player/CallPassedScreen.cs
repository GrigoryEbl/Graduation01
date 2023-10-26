using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallPassedScreen : MonoBehaviour
{
    [SerializeField] private PassedScreen _passedScreen;

    private void Awake()
    {
        _passedScreen = GetComponent<PassedScreen>();
    }

    public void Call()
    {
        _passedScreen.Activate();
    }
}
