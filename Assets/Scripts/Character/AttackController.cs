using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    private IData _data;
    private AnimationController _animationController;
    
    private float _attackIntervalTimer;
    private float _attackDelayTimer;
    private bool _isAttacking;
    
    public void Init()
    {
        _data = GetComponent<IData>();
        _animationController = GetComponent<AnimationController>();
    }

    public bool IsAttacking()
    {
        return _isAttacking;
    }

    public bool IsAttackable(Transform target)
    {
        if (Time.time < _attackIntervalTimer)
            return false;
        
        var dist = Vector2.Distance(transform.position, target.position);
        return dist <= _data.GetAttackRange();
    }

    public void DoAttack(Transform target)
    {
        _attackIntervalTimer = Time.time + _data.GetAttackInterval();
        _attackDelayTimer = Time.time + _data.GetAttackDelay();
        _isAttacking = true;
        
        _animationController.OnAttack();

        var damagable = target.GetComponent<DamageController>();
        if (damagable != null)
        {
            damagable.DoDamage(GenerateAttackInfo());
        }
    }

    public void OnUpdateWhenAttacking()
    {
        if (Time.time >= _attackDelayTimer)
            _isAttacking = false;
    }

    private AttackInfo GenerateAttackInfo()
    {
        return new AttackInfo(_data.GetPower());
    }
}
