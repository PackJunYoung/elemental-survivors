using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawnPoint : MonoBehaviour
{
    public List<MonsterSpawnInfo> spawnInfos;

    private float _timer;
    
    private void Update()
    {
        MonsterSpawnInfo activeSpawnInfo = null;
        foreach (var spawnInfo in spawnInfos)
        {
            if (Time.time > spawnInfo.startTime)
            {
                activeSpawnInfo = spawnInfo;
            }
        }

        if (activeSpawnInfo == null)
            return;
        
        _timer += Time.deltaTime;
        if (_timer > activeSpawnInfo.spawnInterval)
        {
            _timer = 0f;
            SpawnMonster(activeSpawnInfo.monsterId);
        }
    }

    private void SpawnMonster(string monsterId)
    {
        var monster = MonsterManager.instance.GenerateMonster(monsterId);
        monster.transform.position = transform.position;
    }
}
