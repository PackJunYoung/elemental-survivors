using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillProjectileAttack : SkillAttack
{
    private SkillProjectile _skillProjectile;
    
    public override void Init(SkillItem skillItem)
    {
        _skillProjectile = GetComponentInParent<SkillProjectile>();
        
        base.Init(skillItem);
    }

    public override void OnAttacked()
    {
        _skillProjectile.OnAttacked();
    }
}
