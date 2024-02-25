using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackInfo
{
    private readonly float _power;

    public AttackInfo(float power)
    {
        _power = power;
    }

    public float GetPower()
    {
        return _power;
    }
}
