using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindSkillData : MonoBehaviour
{
    [SerializeField] private int _interval;
    [SerializeField] private float _minPower;
    [SerializeField] private float _maxPower;

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
}
