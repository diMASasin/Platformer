using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform _point1;
    [SerializeField] private Transform _point2;
    [SerializeField] private float _pathTime;

    private float _pathRunningTime;
    private bool _isPoint1Target = true;
    private Animator _animator;
    private SpriteRenderer _sprite;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (_isPoint1Target)
        {
            _pathRunningTime += Time.deltaTime;
            _sprite.flipX = false;
        }
        else
        {
            _pathRunningTime -= Time.deltaTime;
            _sprite.flipX = true;
        }

        gameObject.transform.position = Vector2.Lerp(new Vector2(_point2.position.x, transform.position.y), new Vector2(_point1.position.x, transform.position.y), _pathRunningTime / _pathTime);
        _animator.SetBool("IsMoving", true);

        if (transform.position.x == _point1.position.x)
            _isPoint1Target = false;
        else if (transform.position.x == _point2.position.x)
            _isPoint1Target = true;
    }
}
