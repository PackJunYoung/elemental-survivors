using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class HolySkillItem : SkillItem
{
    private HolySkillData _holySkillData;
    
    protected override void OnInit()
    {
        _holySkillData = GetComponent<HolySkillData>();
    }

    protected override async UniTask ProcessSkill()
    {
        await UniTask.Delay(_holySkillData.GetInterval());
        GenerateProjectile();
    }

    public override AttackInfo GetAttackInfo()
    {
        var power = Random.Range(_holySkillData.GetMinPower(), _holySkillData.GetMaxPower());
        return new AttackInfo(power);
    }

    private void GenerateProjectile()
    {
        var direction = HeroManager.Instance.GetMoveDirection();
        if (direction.magnitude >= 0.5f)
        {
            var skillProjectile = SkillManager.Instance.GenerateSkillProjectile(GetSkillType(), transform.position);
            skillProjectile.Init(this);
            skillProjectile.SetMove(direction, _holySkillData.GetMoveSpeed(), true);
        }
    }
}
