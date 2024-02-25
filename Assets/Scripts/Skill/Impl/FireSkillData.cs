using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSkillData : MonoBehaviour
{
    [SerializeField] private int _interval;
    [SerializeField] private float _minPower;
    [SerializeField] private float _maxPower;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private int _attackInterval;
    [SerializeField] private int _attackCount;

    public int GetInterval()
    {
        return _interval;
    }
    
    public float GetMinPower()
    {
        return _minPower;
    }

    public float GetMaxPower()
    {
        return _maxPower;
    }

    public float GetMoveSpeed()
    {
        return _moveSpeed;
    }
    
    public int GetAttackInterval()
    {
        return _attackInterval;
    }

    public int GetAttackCount()
    {
        return _attackCount;
    }
}
