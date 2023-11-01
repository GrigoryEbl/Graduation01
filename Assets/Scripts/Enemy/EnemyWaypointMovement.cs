using UnityEngine;

[RequireComponent (typeof(Scaner))]
[RequireComponent (typeof(SpriteRenderer))]
public class EnemyWaypointMovement : Sounds
{
    [SerializeField] private Transform _path;
    [SerializeField] private float _speed;
    [SerializeField] private Scaner scaner;
    [SerializeField] private Sprite _patrolSprite;
    [SerializeField] private Sprite _dangerousSprite;

    private Transform[] _points;
    private int _currentPoint;
    private Transform _player;
    private Transform _target;
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _points = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
            _points[i] = _path.GetChild(i);

        _player = FindObjectOfType<Player>().transform;

        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = _patrolSprite;
    }

    private void FixedUpdate()
    {
        _target = _points[_currentPoint];

        DetectingPlayer();

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
        if (scaner.Scan())
        {
            _target = _player.transform;
            _spriteRenderer.sprite = _dangerousSprite;

            if(AudioSource.isPlaying == false)
            PlaySound(sounds[0],0.5f);
        }
        else
        {
            _spriteRenderer.sprite = _patrolSprite;
        }
    }
}