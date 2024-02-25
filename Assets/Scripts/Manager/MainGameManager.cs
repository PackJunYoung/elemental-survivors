using UnityEngine;
using UnityEngine.Serialization;

public class MainGameManager : MonoBehaviour
{
    [SerializeField] private MapManager _mapManager;
    [SerializeField] private HeroManager _heroManager;
    [SerializeField] private MonsterManager _monsterManager;
    [SerializeField] private SkillManager _skillManager;
    [SerializeField] private ItemManager _itemManager;
    [SerializeField] private UiManager _uiManager;

    private MainGameData _data;
    
    public static MainGameManager Instance { get; private set; }

    private void Start()
    {
        Instance = this;
        
        _data = GetComponent<MainGameData>();
        _data.Init();

        _mapManager.Init();
        _skillManager.Init();
        _heroManager.Init();
        _itemManager.Init();
        _monsterManager.Init();
        _uiManager.Init();
    }

    public MainGameData GetGameData()
    {
        return _data;
    }
}
