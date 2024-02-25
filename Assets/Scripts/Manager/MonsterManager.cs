using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    [SerializeField] private List<MonsterSpawnPointInfo> _spawnPointInfos;

    private List<MonsterController> _monsterControllers = new List<MonsterController>();

    public static MonsterManager Instance { get; private set; }
    
    public void Init()
    {
        Instance = this;
        GenerateSpawnPoints();
    }

    private void GenerateSpawnPoints()
    {
        foreach (var spawnPointInfo in _spawnPointInfos)
        {
            for (var i = 0; i < spawnPointInfo.count; i++)
            {
                var prefab = Resources.Load<GameObject>($"SpawnPoints/spawnPoint_{spawnPointInfo.monsterSpawnPointId}");
                var go = Instantiate(prefab, transform);
                go.transform.localPosition = MapManager.Instance.GetRandomPositionInsideMap();

                var spawnPoint = go.GetComponent<MonsterSpawnPoint>();
                spawnPoint.Init();
            }
        }
    }

    public MonsterController GenerateMonster(int monsterId)
    {
        var prefab = Resources.Load<GameObject>($"Monsters/monster_{monsterId}");
        var go = Instantiate(prefab, transform);
        
        var monster = go.GetComponent<MonsterController>();
        monster.Init();
        
        _monsterControllers.Add(monster);
        return monster;
    }

    public void RemoveMonster(MonsterController monsterController)
    {
        _monsterControllers.Remove(monsterController);
        Destroy(monsterController.gameObject);
    }

    public MonsterController GetShortestMonster()
    {
        if (_monsterControllers.Count == 0)
            return null;
        
        var heroPosition = HeroManager.Instance.getHeroController().transform.position;
        return _monsterControllers.OrderBy(i => Vector2.Distance(i.transform.position, heroPosition)).First();
    }
}
