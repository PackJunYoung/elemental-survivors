using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterData : MonoBehaviour, IData
{
    [SerializeField] private int _monsterId;
    [SerializeField] private string _monsterName;
    [SerializeField] private float _speed;
    [SerializeField] private float _attackRange;
    [SerializeField] private float _attackInterval;
    [SerializeField] private float _attackDelay;
    [SerializeField] private float _power;
    [SerializeField] private float _hp;
    [SerializeField] private float _damageDelay;
    
    public float GetSpeed()
    {
        return _speed;
    }

    public float GetPower()
    {
        return _power;
    }

    public float GetHp()
    {
        return _hp;
    }

    public float GetDamageDelay()
    {
        return _damageDelay;
    }

    public float GetAttackRange()
    {
        return _attackRange;
    }

    public float GetAttackInterval()
    {
        return _attackInterval;
    }

    public float GetAttackDelay()
    {
        return _attackDelay;
    }
}
