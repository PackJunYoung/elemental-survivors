using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private ItemType _type;

    public void Init()
    {
        gameObject.layer = Constants.ITEM_LAYER_ID;
    }

    public void OnTakeItem()
    {
        HeroManager.Instance.OnTakeItem(_type);
        ItemManager.Instance.RemoveItem(this);
    }
}
