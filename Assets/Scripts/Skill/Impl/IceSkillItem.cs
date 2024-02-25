using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;
using Random = UnityEngine.Random;

public class IceSkillItem : SkillItem
{
    private IceSkillData _iceSkillData;
    
    protected override void OnInit()
    {
        _iceSkillData = GetComponent<IceSkillData>();
    }

    protected override async UniTask ProcessSkill()
    {
        await UniTask.Delay(_iceSkillData.GetInterval());
        GenerateProjectile();
    }

    public override AttackInfo GetAttackInfo()
    {
        var power = Random.Range(_iceSkillData.GetMinPower(), _iceSkillData.GetMaxPower());
        return new AttackInfo(power);
    }

    private void GenerateProjectile()
    {
        var targetMonster = MonsterManager.Instance.GetShortestMonster();
        if (targetMonster != null)
        {
            var direction = targetMonster.transform.position - transform.position;

            var skillProjectile = SkillManager.Instance.GenerateSkillProjectile(GetSkillType(), transform.position);
            skillProjectile.Init(this);
            skillProjectile.SetDestroyIfAttacked(true);
            skillProjectile.SetMove(direction, _iceSkillData.GetMoveSpeed(), true);
        }
    }
}
