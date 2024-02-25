using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class FireSkillItem : SkillItem
{
    private FireSkillData _fireSkillData;
    
    protected override void OnInit()
    {
        _fireSkillData = GetComponent<FireSkillData>();
    }

    protected override async UniTask ProcessSkill()
    {
        GenerateProjectile();
        await UniTask.Delay(_fireSkillData.GetInterval());
    }

    public override AttackInfo GetAttackInfo()
    {
        var power = Random.Range(_fireSkillData.GetMinPower(), _fireSkillData.GetMaxPower());
        return new AttackInfo(power);
    }

    private void GenerateProjectile()
    {
        var skillProjectile = SkillManager.Instance.GenerateSkillProjectile(GetSkillType(), transform.position);
        skillProjectile.Init(this);
        skillProjectile.SetRandomMove(_fireSkillData.GetMoveSpeed());
        skillProjectile.SetContinuousHit(_fireSkillData.GetAttackInterval(), _fireSkillData.GetAttackCount());
    }
}
