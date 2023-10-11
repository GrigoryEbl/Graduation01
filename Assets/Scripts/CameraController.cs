using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _speed;

    private Vector3 _target;

    private void Awake()
    {
        _player = FindObjectOfType<Player>().transform;
    }

    private void Update()
    {
        _target = _player.position;
        _target.z -= 10;
        _target.y += 1;
        transform.position = Vector3.Lerp(transform.position, _target, Time.deltaTime * _speed);

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
    }
}
