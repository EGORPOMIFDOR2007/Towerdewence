using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private List<Point> _targets;
    [SerializeField] private float _speed;
    [SerializeField] private Animator _anim;
    
    public event Action OnEnemyDead;

    public void Init(List<Point> targets)
    {
        _targets = new List<Point>(targets);
    }

    private void FixedUpdate()
    {
        if (_targets.Count > 0)
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();

            Vector2 currentPos = rb.position;
            Vector2 targetPos = _targets[0].transform.position;
            Vector2 newPos = Vector2.MoveTowards(currentPos, targetPos, _speed * Time.fixedDeltaTime);

            float distance = Vector2.Distance(targetPos, currentPos);

          if (distance <= 0.03f)
            {
                _targets.RemoveAt(0);
                if (_targets.Count > 0)
                    PlayAnimation(_targets[0].Direction);
            }
            else
            {
                rb.MovePosition(newPos);
            }
        }
        else
        {
            Dead();
        }
    }
    private void PlayAnimation(PointDirection point)
    {
        switch (point)
        {
            case PointDirection.Up:
                _anim.SetFloat("Movement", 2f);
                break;
            case PointDirection.Down:
                _anim.SetFloat("Movement", 3f);
                break;
            case PointDirection.Right:
                _anim.SetFloat("Movement", 0f);
                break;
            case PointDirection.Lift:
                _anim.SetFloat("Movement", 1f);
                break;
        }    
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Tower>(out var tower))
        {
            tower.AddEnemy(this);
        }
        if (collision.gameObject.TryGetComponent<Bullet >(out var bullet))
        {
            Destroy(bullet.gameObject);
            Dead();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Tower>(out var tower))
        {
            tower.RemoveEnemy(this);
        }
    }
    private void Dead()
    {
        OnEnemyDead?.Invoke();
        OnEnemyDead = null;
        Destroy(gameObject);
    }
}