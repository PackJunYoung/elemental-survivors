using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour, ICharacter
{
    private HeroData _data;
    private MoveController _moveController;
    private AnimationController _animationController;
    private DamageController _damageController;
    private SkillController _skillController;
    
    public void Init()
    {
        _data = gameObject.GetComponent<HeroData>();
        
        _moveController = gameObject.AddComponent<MoveController>();
        _moveController.Init(_data.GetSpeed());
        _animationController = gameObject.AddComponent<AnimationController>();
        _animationController.Init();
        _damageController = gameObject.AddComponent<DamageController>();
        _damageController.Init();
        _skillController = gameObject.AddComponent<SkillController>();
        _skillController.Init();

        gameObject.layer = Constants.HERO_LAYER_ID;
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
        else
        {
            var horizontal = Input.GetAxis("Horizontal");
            var vertical = Input.GetAxis("Vertical");
    
            _moveController.OnUpdate(horizontal, vertical);
            _animationController.OnUpdate(horizontal, vertical);
            
            HeroEvent.OnMoveUpdate.Publish(transform.position);
        }
    }

    public void OnDie()
    {
        // go to lobby
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        var item = other.GetComponent<Item>();
        if (item != null)
        {
            item.OnTakeItem();
        }
    }
}
