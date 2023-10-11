using UnityEngine;

public class EnemyWaypointMovement : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private float _speed;
    [SerializeField] private Scaner scaner;
    [SerializeField] private float _seeBackDistance;

    private Transform[] _points;
    private int _currentPoint;
    private Transform _player;
    private Transform _target;

    private void Start()
    {
        _points = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
            _points[i] = _path.GetChild(i);

        _player = FindObjectOfType<Player>().transform;
    }

    private void Update()
    {
        _target = _points[_currentPoint];

        DetectingPlayer();
        Flip();

        transform.position = Vector2.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);

        if (transform.position == _target.position)
        {
            _currentPoint++;

            if (_currentPoint >= _points.Length)
            {
                _currentPoint = 0;
            }
        }
    }

    private void DetectingPlayer()
    {
        if (scaner.Scan() || Vector3.Distance(transform.position, _player.transform.position) < _seeBackDistance)
        {
            _target = _player.transform;
        }
    }

    private void Flip()
    {
        if (_target.position.x > transform.position.x)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            scaner.RayDirectionFlip();

        }
        else if (_target.position.x < transform.position.x)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            scaner.RayDirectionFlip();
        }
    }
}