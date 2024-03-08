using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator _anim;
    private bool _isMoving;
    
    public void OnStart()
    {
        _anim = GetComponentInChildren<Animator>();
    }

    public void OnUpdate(float horizontal, float vertical)
    {
        var isMoving = horizontal != 0f || vertical != 0f;
        if (_isMoving != isMoving)
        {
            _isMoving = isMoving;
            _anim.Play(_isMoving ? "Move" : "Idle");
        }
    }
}
