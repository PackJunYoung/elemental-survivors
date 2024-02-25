using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;
using Random = UnityEngine.Random;

public class WindSkillItem : SkillItem
{
    private SkillAttack _skillAttack;
    private WindSkillData _windSkillData;
    
    protected override void OnInit()
    {
        _windSkillData = GetComponent<WindSkillData>();
        _skillAttack = GetComponentInChildren<SkillAttack>();
        _skillAttack.Init(this);
    }

    protected override async UniTask ProcessSkill()
    {
        var halfInterval = _windSkillData.GetInterval() / 2;
        
        _skillAttack.gameObject.SetActive(false);
        await UniTask.Delay(halfInterval);
        _skillAttack.gameObject.SetActive(true);
        await UniTask.Delay(halfInterval);
    }

    public override AttackInfo GetAttackInfo()
    {
        var power = Random.Range(_windSkillData.GetMinPower(), _windSkillData.GetMaxPower());
        return new AttackInfo(power);
    }
}
