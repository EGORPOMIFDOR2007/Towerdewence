using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private Transform _target;
    [SerializeField] private float _speed;
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (_target == null)
        {
            Destroy(gameObject);
            return;
        }
        var direction = (Vector2)(_target.position - _rigidbody2D.transform.position);
        _rigidbody2D.transform.up = direction;
        _rigidbody2D.velocity = _rigidbody2D.transform.up * _speed;
    }
    public void SetTarget(Transform target)
    {
        _target = target;
    }
}
