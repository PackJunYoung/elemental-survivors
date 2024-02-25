using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class SkillItem : MonoBehaviour
{
    [SerializeField] private SkillType _type;

    private int _level;
    private bool _isPause;

    public SkillType GetSkillType()
    {
        return _type;
    }

    public void RenewLevel(int level)
    {
        _level = level;
    }

    public void Init()
    {
        OnInit();
        StartSkill().Forget();
    }

    private async UniTask StartSkill()
    {
        while (!_isPause)
        {
            await ProcessSkill();
        }
    }

    protected virtual void OnInit()
    {
    }

    protected virtual async UniTask ProcessSkill()
    {
    }

    public virtual AttackInfo GetAttackInfo()
    {
        return null;
    }
}
