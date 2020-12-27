using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private int _velocityModifier;
    [SerializeField] private float _jumpForce;

    private Vector2 _velocity;
    private Vector2 _targetVelocity;
    private Rigidbody2D _rigidbody2d;
    private GroundChecker _groundChecker;
    private Animator _animator;
    private SpriteRenderer _sprite;
    private bool _isDead = false;

    private void Start()
    {
        _rigidbody2d = GetComponent<Rigidbody2D>();
        _groundChecker = GetComponentInChildren <GroundChecker>();
        _animator = GetComponent<Animator>();
        _sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (_isDead)
            return;

        _targetVelocity = new Vector2(Input.GetAxis("Horizontal"), 0);

        if (_targetVelocity.x != 0)
        {
            _animator.SetBool("IsMoving", true);
            if (_targetVelocity.x < 0)
                _sprite.flipX = true;
            else
                _sprite.flipX = false;
        }
        else
        {
            _animator.SetBool("IsMoving", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && _groundChecker.Grounded)
            _rigidbody2d.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }

    private void FixedUpdate()
    {
        _velocity = _targetVelocity * _velocityModifier * Time.deltaTime;
        _rigidbody2d.position += _velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent<EnemyMovement>(out EnemyMovement enemy))
        {
            _targetVelocity = Vector2.zero;
            _velocity = Vector2.zero;
            _animator.SetBool("IsMoving", false);
            _isDead = true;
            _sprite.color = new Color32(55, 55, 55, 255);
        }
    }
}
