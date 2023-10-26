using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ControllForPC
{
    public class MoverForPC : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _body;
        [SerializeField] private GameObject _groundCheckPoint;
        [SerializeField] private LayerMask _groundLayer;
        [SerializeField] private float _targetSpeed;
        [SerializeField] private float _jumpForce;
        [SerializeField] private FinalTrigger _finalTrigger;

        private Animator _animator;
        private SpriteRenderer _spriteRenderer;
        private float _currentSpeed;
        private float _groundCheckRadius = 0.1f;
        private bool _isGrounded;
        private Player _player;

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
            _player = GetComponent<Player>();
            _finalTrigger = FindObjectOfType<FinalTrigger>();
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

        private void Jump()
        {
            if (_isGrounded == true)
                _body.velocity = new Vector2(_body.velocity.x, _jumpForce);

            if (_isGrounded == false)
                State = States.jump;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.gameObject.name == "MovingPlatform")
            transform.parent = collision.transform;

        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.name == "MovingPlatform")
                transform.parent = null;
        }

        private void OnEnable()
        {
            _player.Died += OnDied;
            _finalTrigger.Final += OnFinal;
        }

        private void OnDisable()
        {
            _player.Died -= OnDied;
            _finalTrigger.Final -= OnFinal;
        }

        private void OnDied()
        {
            State = States.death;
        }

        private void OnFinal()
        {
            State = States.modify;
        }
    }

    public enum States
    {
        idle,
        run,
        jump,
        death,
        modify
    }
}

