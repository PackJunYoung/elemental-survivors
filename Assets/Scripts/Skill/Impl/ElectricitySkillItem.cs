using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class ElectricitySkillItem : SkillItem
{
    private ElectricitySkillData _electricitySkillData;
    
    protected override void OnInit()
    {
        _electricitySkillData = GetComponent<ElectricitySkillData>();
    }

    protected override async UniTask ProcessSkill()
    {
        await UniTask.Delay(_electricitySkillData.GetInterval());
        GenerateProjectile();
    }

    public override AttackInfo GetAttackInfo()
    {
        var power = Random.Range(_electricitySkillData.GetMinPower(), _electricitySkillData.GetMaxPower());
        return new AttackInfo(power);
    }

    private void GenerateProjectile()
    {
        var xDistance = Random.Range(-_electricitySkillData.GetMaxDistance(), _electricitySkillData.GetMaxDistance());
        var yDistance = Random.Range(-_electricitySkillData.GetMaxDistance(), _electricitySkillData.GetMaxDistance());
        var position = transform.position + new Vector3(xDistance, yDistance, 0f);

        var skillProjectile = SkillManager.Instance.GenerateSkillProjectile(GetSkillType(), MapManager.Instance.GetPositionInsideMap(position));
        skillProjectile.Init(this);
        skillProjectile.SetAutoDestroy(_electricitySkillData.GetTime());
    }
}
