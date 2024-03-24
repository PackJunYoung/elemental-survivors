using UnityEngine;

public class MainGameManager : MonoBehaviour
{
    public static MainGameManager instance;
    
    public MapManager mapManager;
    public MonsterManager monsterManager;

    private void Start()
    {
        instance = this;
        
        mapManager.Init();
        monsterManager.Init();
    }
}
