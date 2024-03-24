using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    public static MonsterManager instance;

    public List<MonsterSpawnPointInfo> monsterSpawnPointInfos;

    private List<MonsterController> monsterControllers = new List<MonsterController>();

    public void Init()
    {
        instance = this;
        GenerateSpawnPoints();
    }

    private void GenerateSpawnPoints()
    {
        foreach (var monsterSpawnPointInfo in monsterSpawnPointInfos)
        {
            for (var i = 0; i < monsterSpawnPointInfo.count; i++)
            {
                var spawnPointPrefab = Resources.Load<GameObject>($"SpawnPoints/SpawnPoint_{monsterSpawnPointInfo.monsterSpawnPointId}");
                var spawnPoint = Instantiate(spawnPointPrefab, transform);
                spawnPoint.transform.position = MapManager.instance.GetRandomPositionInsideMap();
            }
        }
    }

    public GameObject GenerateMonster(string monsterId)
    {
        var monsterPrefab = Resources.Load<GameObject>($"Monsters/monster_{monsterId}");
        var monster = Instantiate(monsterPrefab, transform);
        var monsterCont = monster.GetComponent<MonsterController>();
        monsterCont.Init();
        monsterControllers.Add(monsterCont);

        return monster;
    }

    public void RemoveMonster(MonsterController monsterCont)
    {
        monsterControllers.Remove(monsterCont);
        Destroy(monsterCont.gameObject);
    }
}
