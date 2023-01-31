using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private List<Point> _targets;
    [SerializeField] private float _cd;
    [SerializeField] private int _enemiesPerWave;
    [SerializeField] private float _cd2;
    [SerializeField] private int _enemyCount;
    [SerializeField] private float _timer;
    [SerializeField] private SpawnerState _state;

    private enum SpawnerState
    {
        SpawnEnemy,
        Attacking,
        Cooldown,
    }

   void Start()
    {
        _enemyCount = 0;
        _timer = _cd;  
    }

    
    void Update()
    {
        switch (_state)
        {     
            case SpawnerState.SpawnEnemy: 
                _timer -= Time.deltaTime;
                if (_timer < 0)
                {
                    Enemy enemy = Instantiate(_enemy, transform);
                    enemy.Init(_targets);
                    enemy.OnEnemyDead += RemoveEnemy;
                    _timer += _cd;
                    _enemyCount++;
                }
                if (_enemyCount >= _enemiesPerWave)
                {
                    _state = SpawnerState.Attacking;
                }
                break;

            case SpawnerState.Attacking: 
                if (_enemyCount <= 0)
                {
                _timer = _cd2;
                _state = SpawnerState.Cooldown;

                }
                break;
            case SpawnerState.Cooldown: 
                _timer -= Time.deltaTime;
                if (_timer < 0)
                {
                    _state = SpawnerState.SpawnEnemy;
                }
                    break;
        }   
    }
    private void RemoveEnemy()
    {
        _enemyCount --;
    }
}
