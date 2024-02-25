using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillAttack : MonoBehaviour
{
    private SkillItem _skillItem;
    
    public virtual void Init(SkillItem skillItem)
    {
        _skillItem = skillItem;
        gameObject.layer = Constants.SKILL_ATTACK_LAYER_ID;
    }

    public AttackInfo GetAttackInfo()
    {
        return _skillItem.GetAttackInfo();
    }

    public virtual void OnAttacked()
    {
    }
}
