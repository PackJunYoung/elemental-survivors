using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SkillController : MonoBehaviour
{
    private List<SkillInfo> _skillInfos = new List<SkillInfo>();
    private List<SkillItem> _skillItems = new List<SkillItem>();

    public void Init()
    {
        var initialSkillType = MainGameManager.Instance.GetGameData().GetInitialSkillType();
        var initialSkillLevel = MainGameManager.Instance.GetGameData().GetInitialSkillLevel();
        _skillInfos.Add(new SkillInfo(initialSkillType, initialSkillLevel));
        
        RenewSkillItem();
    }

    public void OnLevelUp(SkillType skillType)
    {
        if (_skillInfos.Exists(s => s.GetSkillType() == skillType))
        {
            var skillInfo =_skillInfos.Find(s => s.GetSkillType() == skillType);
            skillInfo.PlusSkillLevel();
        }
        else
        {
            _skillInfos.Add(new SkillInfo(skillType, 1));
        }
        
        RenewSkillItem();
    }

    private void RenewSkillItem()
    {
        foreach (var skillInfo in _skillInfos)
        {
            if (!_skillItems.Exists(i => i.GetSkillType() == skillInfo.GetSkillType()))
            {
                AttachSkillItem(skillInfo);
            }

            var skillItem = _skillItems.Find(i => i.GetSkillType() == skillInfo.GetSkillType());
            skillItem.RenewLevel(skillInfo.GetSkillLevel());
        }
    }

    private void AttachSkillItem(SkillInfo skillInfo)
    {
        var skillItem = SkillManager.Instance.GenerateSkillItem(skillInfo.GetSkillType(), transform);
        skillItem.Init();
        
        _skillItems.Add(skillItem);
    }
}
