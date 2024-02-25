using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SkillInfo
{
    private SkillType _type;
    private int _level;

    public SkillInfo(SkillType type, int level)
    {
        _type = type;
        _level = level;
    }

    public SkillType GetSkillType()
    {
        return _type;
    }

    public int GetSkillLevel()
    {
        return _level;
    }

    public void PlusSkillLevel()
    {
        _level++;
    }
}
