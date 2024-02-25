using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    private IData _data;
    private ICharacter _character;
    private AnimationController _animationController;

    private float _maxHp;
    private float _currentHp;
    private float _damageDelayTimer;
    private bool _isDamaging;
    private bool _isDied;
    
    public void Init()
    {
        _data = GetComponent<IData>();
        _character = GetComponent<ICharacter>();
        _animationController = GetComponent<AnimationController>();
        
        _maxHp = _currentHp = _data.GetHp();
    }

    public bool IsDamaging()
    {
        return _isDamaging;
    }

    public bool IsDied()
    {
        return _isDied;
    }

    public void DoDamage(AttackInfo attackInfo)
    {
        _currentHp -= attackInfo.GetPower();
        _isDamaging = true;
        _damageDelayTimer = Time.time + _data.GetDamageDelay();

        if (_currentHp <= 0f)
        {
            _isDied = true;
            _character.OnDie();
            _animationController.OnDie();
        }
        else
        {
            _animationController.OnDamage();
        }

        if (_data is HeroData)
        {
            MessageBroker.Default.Publish(UiEvent.InvalidateHp.Instance);
        }
        else
        {
            // show damage font
        }
    }

    public void DoRecover(float amount)
    {
        _currentHp = Mathf.Min(_currentHp + amount, _maxHp);
        
        if (_data is HeroData)
        {
            MessageBroker.Default.Publish(UiEvent.InvalidateHp.Instance);
        }
    }
    
    public void OnUpdateWhenDamaging()
    {
        if (Time.time >= _damageDelayTimer)
            _isDamaging = false;
    }

    public float GetCurrentHp()
    {
        return _currentHp;
    }

    public float GetMaxHp()
    {
        return _maxHp;
    }
}
