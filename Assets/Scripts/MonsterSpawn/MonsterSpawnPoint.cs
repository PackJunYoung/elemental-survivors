using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Random = UnityEngine.Random;

public class MonsterSpawnPoint : MonoBehaviour
{
    [SerializeField] private List<MonsterSpawnInfo> _spawnInfos;

    private float _timer;
    private float _currentInterval;
    private List<int> _monsterIds = new List<int>();

    public void Init()
    {
        Observable.Interval(TimeSpan.FromSeconds(1)).Subscribe(_ =>
        {
            CheckSpawnPoint();
            UpdateSpawnPoint();
        }).AddTo(gameObject);
    }

    private void CheckSpawnPoint()
    {
        var elapsedTime = MainGameManager.Instance.GetGameData().GetElapsedTime();
        foreach (var spawnInfo in _spawnInfos)
        {
            if (elapsedTime >= spawnInfo.startTime && !spawnInfo.IsActive())
            {
                spawnInfo.OnActive();
                _currentInterval = spawnInfo.spawnInterval;
                _monsterIds.Add(spawnInfo.monsterId);
            }
        }
    }

    private void UpdateSpawnPoint()
    {
        if (_monsterIds.Count == 0)
            return;

        if (Time.time > _timer)
        {
            _timer = Time.time + _currentInterval;
            SpawnMonster();
        }
    }

    private void SpawnMonster()
    {
        var selectedId = _monsterIds[Random.Range(0, _monsterIds.Count)];
        var monster = MonsterManager.Instance.GenerateMonster(selectedId);
        
        monster.transform.position = transform.position;
    }
}
