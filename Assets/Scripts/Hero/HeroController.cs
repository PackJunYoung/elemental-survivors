using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour
{
    private HeroData _data;
    private MoveController _moveController;
    private AnimationController _animationController;
    
    void Start()
    {
        _data = gameObject.GetComponent<HeroData>();
        _moveController = gameObject.AddComponent<MoveController>();
        _animationController = gameObject.AddComponent<AnimationController>();
        _moveController.OnStart(_data.speed);
        _animationController.OnStart();
    }
    
    void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        _moveController.OnUpdate(horizontal, vertical);
        _animationController.OnUpdate(horizontal, vertical);
    }
}
