using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricitySkillData : MonoBehaviour
{
    [SerializeField] private int _interval;
    [SerializeField] private float _minPower;
    [SerializeField] private float _maxPower;
    [SerializeField] private int _time;
    [SerializeField] private float _maxDistance;
    
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

    public int GetTime()
    {
        return _time;
    }

    public float GetMaxDistance()
    {
        return _maxDistance;
    }
}
