using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator _anim;
    private bool _isMoving;

    private static int MOVE_STATE = Animator.StringToHash("Move");
    private static int IDLE_STATE = Animator.StringToHash("Idle");
    private static int ATTACK_STATE = Animator.StringToHash("Attack");
    private static int TAKE_HIT_STATE = Animator.StringToHash("Take Hit");
    private static int DIE_STATE = Animator.StringToHash("Death");
    
    public void Init()
    {
        _anim = GetComponentInChildren<Animator>();
    }
    
    public void OnUpdate(float horizontal, float vertical)
    {
        var isMoving = horizontal != 0f || vertical != 0;
        if (_isMoving != isMoving)
        {
            _isMoving = isMoving;
            _anim.Play(_isMoving ? MOVE_STATE : IDLE_STATE);
        }
    }

    public void OnAttack()
    {
        _isMoving = false;
        _anim.Play(ATTACK_STATE);
    }

    public void OnDamage()
    {
        _isMoving = false;
        _anim.Play(TAKE_HIT_STATE);
    }

    public void OnDie()
    {
        _isMoving = false;
        _anim.Play(DIE_STATE);
    }
}
