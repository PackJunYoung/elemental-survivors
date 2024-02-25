using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    private UiExp _uiExp;
    private UiLevel _uiLevel;
    private UiHp _uiHp;
    private UiTime _uiTime;
    
    public static UiManager Instance { get; private set; }

    public void Init()
    {
        Instance = this;

        _uiExp = GetComponentInChildren<UiExp>();
        _uiExp.Init();
        _uiLevel = GetComponentInChildren<UiLevel>();
        _uiLevel.Init();
        _uiHp = GetComponentInChildren<UiHp>();
        _uiHp.Init();
        _uiTime = GetComponentInChildren<UiTime>();
        _uiTime.Init();
        
        SetSubscribe();
    }

    private void SetSubscribe()
    {
        Observable.Interval(TimeSpan.FromSeconds(1)).Subscribe(_ =>
        {
            MessageBroker.Default.Publish(UiEvent.InvalidateTime.Instance);
        }).AddTo(gameObject);
    }
}
