using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static ItemManager Instance { get; private set; }
    
    public void Init()
    {
        Instance = this;
    }

    public void OnMonsterDie(MonsterController monsterController)
    {
        var itemType = GetRandomItemType();
        var item = GenerateItem(itemType);
        var monsterPosition = monsterController.transform.position;
        item.transform.position = new Vector3(monsterPosition.x, monsterPosition.y, 1f);
        item.Init();
    }

    private Item GenerateItem(ItemType itemType)
    {
        var prefab = Resources.Load<GameObject>($"Items/{itemType.ToString().ToLower()}");
        var go = Instantiate(prefab, transform);

        return go.GetComponent<Item>();
    }

    public void RemoveItem(Item item)
    {
        Destroy(item.gameObject);
    }

    private ItemType GetRandomItemType()
    {
        var potionProb = MainGameManager.Instance.GetGameData().GetPotionProb();
        return Random.value < potionProb ? ItemType.POTION : ItemType.EXP;
    }
}
