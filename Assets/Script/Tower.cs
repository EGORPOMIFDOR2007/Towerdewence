using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TowerState
{
    Idle , 
    Attack ,
    Reload 
}
public class Tower : MonoBehaviour
{
    private LinkedList <Enemy> _enemylist = new LinkedList <Enemy>();
    private Enemy _target;
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private TowerType _type;
    [SerializeField] private TowerState _state;
    [SerializeField] private float _reloadTime;
    private float _curentTime;
    [SerializeField] private GradeType _gradeType;

    public TowerType Type => _type;
    public GradeType GradeType => _gradeType;
    public void AddEnemy(Enemy x)
    {
        _enemylist.AddFirst (x);
    }
    public void RemoveEnemy(Enemy x)
    {
        _enemylist.Remove (x);
    }
    
    private bool TrySetTarget()
    {
        var result = false;
        
        if (_enemylist .Count > 0)
        {
            var node = _enemylist.Last;
            var distance = float.PositiveInfinity;
            var currentDistance = float.PositiveInfinity;
            while (node != null)
            {
                currentDistance = (node.Value.transform.position - transform.position).magnitude;
                if (currentDistance < distance )
                {
                    _target = node.Value;
                    result = true;
                    distance = currentDistance;
                }
                node = node.Next;
            }
        }



        return result;
    }
    private void Update()
    {
        switch (_state)
        {
            case TowerState.Idle:
                if (TrySetTarget())
                {
                    _state = TowerState.Attack;
                }
                break;
            case TowerState.Attack:
                var bullet = Instantiate (_bulletPrefab ,transform.position ,Quaternion.identity);
                bullet.SetTarget(_target.transform);
                _curentTime = Time.time + _reloadTime;
                _state = TowerState.Reload;
                break;
            case TowerState.Reload:
                if (_curentTime <= Time.time)
                {
                    _state = TowerState.Idle;
                }
                break;
        }

    }
}
