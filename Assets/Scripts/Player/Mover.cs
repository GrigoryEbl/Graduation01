using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Player))]

public class Mover : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _body;
    [SerializeField] private GameObject _groundCheckPoint;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private float _targetSpeed;
    [SerializeField] private float _jumpForce;

    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private float _currentSpeed;
    private float _groundCheckRadius = 0.1f;
    private bool _isGrounded;

    private States State
    {
        get { return (States)_animator.GetInteger("State"); }
        set { _animator.SetInteger("State", (int)value); }
    }

    private void Awake()
    {
        _body.GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        _isGrounded = Physics2D.OverlapCircle(_groundCheckPoint.transform.position, _groundCheckRadius, _groundLayer);

        if (_isGrounded == true)
            State = States.idle;

        if (Input.GetButton("Jump"))
            Jump();

        if (Input.GetButton("Horizontal"))
            Run();
        else
            _currentSpeed = 0;
    }

    public void Run()
    {
        _currentSpeed = _targetSpeed;

        if (_isGrounded == true)
            State = States.run;

        Vector3 direction = transform.right * Input.GetAxis("Horizontal");

        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, _currentSpeed * Time.deltaTime);

        _spriteRenderer.flipX = direction.x < 0;
    }

    public void Jump()
    {
        if (_isGrounded == true)
            _body.velocity = new Vector2(0, _jumpForce);

        if (_isGrounded == false)
            State = States.jump;
    }
}

public enum States
{
    idle,
    run,
    jump
}