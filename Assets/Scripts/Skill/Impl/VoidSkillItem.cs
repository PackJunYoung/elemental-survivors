using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class VoidSkillItem : SkillItem
{
    private VoidSkillData _voiSkillData;
    
    protected override void OnInit()
    {
        _voiSkillData = GetComponent<VoidSkillData>();
    }

    protected override async UniTask ProcessSkill()
    {
        await UniTask.Delay(_voiSkillData.GetInterval());
        GenerateProjectile();
    }

    public override AttackInfo GetAttackInfo()
    {
        var power = Random.Range(_voiSkillData.GetMinPower(), _voiSkillData.GetMaxPower());
        return new AttackInfo(power);
    }

    private void GenerateProjectile()
    {
        var targetMonster = MonsterManager.Instance.GetShortestMonster();
        if (targetMonster != null)
        {
            var skillProjectile = SkillManager.Instance.GenerateSkillProjectile(GetSkillType(), transform.position);
            skillProjectile.Init(this);
            skillProjectile.SetContinuousHit(_voiSkillData.GetAttackInterval(), _voiSkillData.GetAttackCount());
        }
    }
}
