using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroData : MonoBehaviour, IData
{
    [SerializeField] private float _speed;
    [SerializeField] private float _hp;
    [SerializeField] private float _damageDelay;

    public float GetPower()
    {
        return 0f;
    }

    public float GetHp()
    {
        return _hp;
    }

    public float GetDamageDelay()
    {
        return _damageDelay;
    }

    public float GetSpeed()
    {
        return _speed;
    }

    public float GetAttackRange()
    {
        return 0f;
    }

    public float GetAttackInterval()
    {
        return 0f;
    }

    public float GetAttackDelay()
    {
        return 0f;
    }
}
