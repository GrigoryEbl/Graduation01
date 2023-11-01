using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioToggler : MonoBehaviour
{
    [SerializeField] private Sprite[] _sprites;

    private bool _isOn;
    private Image _image;

    void Start()
    {
        _image = GetComponent<Image>();
        _isOn = true;
    }

    public void OnOffSounds()
    {
        if(_isOn == false)
        {
            AudioListener.volume = 1f;
            _isOn = true;
            _image.sprite = _sprites[0];
        }
        else if(_isOn)
        {
            AudioListener.volume = 0f;
            _isOn = false;
            _image.sprite = _sprites[1];
        }
    }
}
