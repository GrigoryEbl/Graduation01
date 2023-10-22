using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace ControllForPhone
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(Player))]

    public class MoverForPhones : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _body;
        [SerializeField] private GameObject _groundCheckPoint;
        [SerializeField] private LayerMask _groundLayer;
        [SerializeField] private float _jumpForce;

        private SpriteRenderer _spriteRenderer;
        private Animator _animator;
        private float _speed;
        private float _groundCheckRadius = 0.2f;
        private bool _isGrounded;
        public float _normalSpeed;

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

            _body.velocity = new Vector2(_speed, _body.velocity.y);

            if (_isGrounded && _speed == 0)
                State = States.idle;
            else if (!_isGrounded)
                State = States.jump;
        }

        private void Jump()
        {
            if (_isGrounded == true)
                _body.velocity = new Vector2(_body.velocity.x, _jumpForce);

            if (_isGrounded == false)
                State = States.jump;
        }

        public void OnLeftButtonDown()
        {
            if (_speed >= 0f)
            {
                State = States.run;
                _speed = -_normalSpeed;
                Flip();
            }
        }
        public void OnRightButtonDown()
        {
            if (_speed <= 0f)
            {
                State = States.run;
                _speed = _normalSpeed;
                Flip();
            }
        }

        public void OnJumpButtonDown()
        {
            Jump();
        }

        public void OnButtonUp()
        {
            _speed = 0f;
        }

        private void Flip()
        {
            _spriteRenderer.flipX = _speed < 0;
        }
    }

    public enum States
    {
        idle,
        run,
        jump
    }
}