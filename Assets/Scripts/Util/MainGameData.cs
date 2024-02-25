using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameData : MonoBehaviour
{
    [SerializeField] private float _potionProb;
    [SerializeField] private float _potionRecoverAmount;
    [SerializeField] private SkillType _initialSkillType;
    [SerializeField] private int _initialSkillLevel;
    [SerializeField] private int _baseExp;
    [SerializeField] private int _additionalExp;

    private float _startTime;

    public void Init()
    {
        _startTime = Time.time;
    }
    
    public float GetElapsedTime()
    {
        return Time.time - _startTime;
    }
    
    public float GetPotionProb()
    {
        return _potionProb;
    }

    public float GetPotionRecoverAmount()
    {
        return _potionRecoverAmount;
    }
    
    public SkillType GetInitialSkillType()
    {
        return _initialSkillType;
    }

    public int GetInitialSkillLevel()
    {
        return _initialSkillLevel;
    }

    public int GetBaseExp()
    {
        return _baseExp;
    }

    public int GetAdditionalExp()
    {
        return _additionalExp;
    }
}
