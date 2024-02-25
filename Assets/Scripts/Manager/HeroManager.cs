using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Random = UnityEngine.Random;

public class HeroManager : MonoBehaviour
{
    public static HeroManager Instance { get; private set; }

    private HeroController _heroController;
    private MoveController _heroMoveController;
    private DamageController _heroDamageController;
    private SkillController _heroSkillController;

    private int _currentLevel;
    private int _currentExp;

    public void Init()
    {
        Instance = this;

        _heroController = GenerateHero();
        _heroController.Init();
        _heroMoveController = _heroController.GetComponent<MoveController>();
        _heroDamageController = _heroController.GetComponent<DamageController>();
        _heroSkillController = _heroController.GetComponent<SkillController>();
    }
    
    public HeroController getHeroController()
    {
        return _heroController;
    } 

    private HeroController GenerateHero()
    {
        var prefab = Resources.Load<GameObject>("Hero/hero");
        var go = Instantiate(prefab);
        return go.GetComponent<HeroController>();
    }

    public void OnTakeItem(ItemType itemType)
    {
        if (itemType == ItemType.EXP)
        {
            OnTakeExp();
        } 
        else if (itemType == ItemType.POTION)
        {
            OnTakePotion();
        }
    }

    private void OnTakeExp()
    {
        _currentExp += 1;
        if (_currentExp >= GetRequireExp())
        {
            DoLevelUp();
        }
        
        MessageBroker.Default.Publish(UiEvent.InvalidateExp.Instance);
    }

    private void OnTakePotion()
    {
        var potionRecoverAmount = MainGameManager.Instance.GetGameData().GetPotionRecoverAmount();
        _heroDamageController.DoRecover(potionRecoverAmount);
    }

    public int GetCurrentLevel()
    {
        return _currentLevel;
    }

    public float GetExpRatio()
    {
        return (float)_currentExp / GetRequireExp();
    }

    public float GetHpRatio()
    {
        return _heroDamageController.GetCurrentHp() / _heroDamageController.GetMaxHp();
    }

    public Vector3 GetMoveDirection()
    {
        return _heroMoveController.GetDirection();
    }

    private int GetRequireExp()
    {
        var baseExp = MainGameManager.Instance.GetGameData().GetBaseExp();
        var additionalExp = MainGameManager.Instance.GetGameData().GetAdditionalExp();
        return baseExp + additionalExp * _currentLevel;
    }

    private void DoLevelUp()
    {
        _currentLevel++;
        _currentExp = 0;

        var skillTypes = Enum.GetValues(typeof(SkillType));
        var selectedSkillTypeIndex = Random.Range(0, skillTypes.Length);
        var selectedSkillType = (SkillType)selectedSkillTypeIndex;
        _heroSkillController.OnLevelUp(selectedSkillType);

        Debug.Log($"[DoLevelUp] currentLevel: {_currentLevel}");
        MessageBroker.Default.Publish(UiEvent.InvalidateLevel.Instance);
    }
}
