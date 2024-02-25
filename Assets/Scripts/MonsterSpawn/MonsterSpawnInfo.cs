using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class MonsterSpawnInfo
{
    public float startTime;
    public int monsterId;
    public float spawnInterval;

    private bool _isActive;

    public void OnActive()
    {
        _isActive = true;
    }

    public bool IsActive()
    {
        return _isActive;
    }
}
