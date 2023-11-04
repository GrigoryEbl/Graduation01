using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _speed;
    [SerializeField] private int _cameraPositionZ;
    [SerializeField] private int _cameraPositionY;

    private Vector3 _target;

    private void Awake()
    {
        _player = FindObjectOfType<Player>().transform;
    }

    private void Update()
    {
        _target = _player.position;
        _target.z = _cameraPositionZ;
        _target.y += _cameraPositionY;
        transform.position = Vector3.Lerp(transform.position, _target, Time.deltaTime * _speed);
    }
}
