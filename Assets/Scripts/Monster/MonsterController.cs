using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class MonsterController : MonoBehaviour, ICharacter
{
    private MonsterData _data;
    private MoveController _moveController;
    private AnimationController _animationController;
    private AttackController _attackController;
    private DamageController _damageController;

    private Transform _target;
    private SpriteRenderer _renderer;
    
    public void Init()
    {
        _data = gameObject.GetComponent<MonsterData>();
        _renderer = gameObject.GetComponentInChildren<SpriteRenderer>();
        
        _moveController = gameObject.AddComponent<MoveController>();
        _moveController.Init(_data.GetSpeed());
        _animationController = gameObject.AddComponent<AnimationController>();
        _animationController.Init();
        _attackController = gameObject.AddComponent<AttackController>();
        _attackController.Init();
        _damageController = gameObject.AddComponent<DamageController>();
        _damageController.Init();

        _target = HeroManager.Instance.getHeroController().transform;
        gameObject.layer = Constants.MONSTER_LAYER_ID;
    }
    
    private void Update()
    {
        if (_damageController.IsDied())
        {
        }
        else if (_damageController.IsDamaging())
        {
            _damageController.OnUpdateWhenDamaging();
        }
        else if (_attackController.IsAttacking())
        {
            _attackController.OnUpdateWhenAttacking();
        }
        else if (_attackController.IsAttackable(_target))
        {
            _attackController.DoAttack(_target);
        }
        else
        {
            var dir = _target.position - transform.position;
            dir.z = 0f;
            dir.Normalize();
            var horizontal = dir.x;
            var vertical = dir.y;
            
            _moveController.OnUpdate(horizontal, vertical);
            _animationController.OnUpdate(horizontal, vertical);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var skillAttack = other.GetComponent<SkillAttack>();
        if (skillAttack != null)
        {
            var attackInfo = skillAttack.GetAttackInfo();
            skillAttack.OnAttacked();
            _damageController.DoDamage(attackInfo);
        }
    }

    public void OnDie()
    {
        ItemManager.Instance.OnMonsterDie(this);
        
        Observable.Timer(TimeSpan.FromSeconds(0.5f)).Subscribe(_ =>
        {
            _renderer.color = new Color(1f, 1f, 1f, 0.5f);
        }).AddTo(gameObject);
        
        Observable.Timer(TimeSpan.FromSeconds(1)).Subscribe(_ =>
        {
            MonsterManager.Instance.RemoveMonster(this);
        }).AddTo(gameObject);
    }
}
