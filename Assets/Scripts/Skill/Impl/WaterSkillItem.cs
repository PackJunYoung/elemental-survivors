using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class WaterSkillItem : SkillItem
{
    private WaterSkillData _waterSkillData;
    
    protected override void OnInit()
    {
        _waterSkillData = GetComponent<WaterSkillData>();
    }

    protected override async UniTask ProcessSkill()
    {
        await UniTask.Delay(_waterSkillData.GetInterval());
        GenerateProjectile();
    }

    public override AttackInfo GetAttackInfo()
    {
        var power = Random.Range(_waterSkillData.GetMinPower(), _waterSkillData.GetMaxPower());
        return new AttackInfo(power);
    }

    private void GenerateProjectile()
    {
        var leftSkillProjectile = SkillManager.Instance.GenerateSkillProjectile(GetSkillType(), transform.position);
        leftSkillProjectile.Init(this);
        leftSkillProjectile.SetMove(-Vector2.right, _waterSkillData.GetMoveSpeed(), false);
        leftSkillProjectile.transform.localScale = new Vector3(-1f, 1f, 1f);
        
        var rightSkillProjectile = SkillManager.Instance.GenerateSkillProjectile(GetSkillType(), transform.position);
        rightSkillProjectile.Init(this);
        rightSkillProjectile.SetMove(Vector2.right, _waterSkillData.GetMoveSpeed(), false);
    }
}
