using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;

public class SkillProjectile : MonoBehaviour
{
    private SkillAttack _skillAttack;

    private bool _destroyIfAttacked;
    private Vector3 _moveDirection;
    private float _moveSpeed;
    private bool _isMoving;
    private bool _isRandomMoving;
    private float _randomMoveDirectionTimer;

    public void Init(SkillItem skillItem)
    {
        _skillAttack = GetComponentInChildren<SkillAttack>();
        _skillAttack.Init(skillItem);
    }
    
    public void SetMove(Vector2 moveDirection, float moveSpeed, bool isAngleDirection)
    {
        _moveDirection = moveDirection;
        _moveSpeed = moveSpeed;
        _isMoving = true;

        if (isAngleDirection)
        {
            SetAngle();
        }
    }

    public void SetRandomMove(float moveSpeed)
    {
        _moveSpeed = moveSpeed;
        _isMoving = true;
        _isRandomMoving = true;
    }

    public void SetDestroyIfAttacked(bool destroyIfAttacked)
    {
        _destroyIfAttacked = destroyIfAttacked;
    }

    public async UniTask SetAutoDestroy(int time)
    {
        await UniTask.Delay(time);
        SkillManager.Instance.RemoveSkillProjectile(this);
    }

    public async UniTask SetContinuousHit(int interval, int count)
    {
        var halfInterval = interval / 2;
        for (var i = 0; i < count; i++)
        {
            _skillAttack.gameObject.SetActive(false);
            await UniTask.Delay(halfInterval);
            _skillAttack.gameObject.SetActive(true);
            await UniTask.Delay(halfInterval);
        }
        SkillManager.Instance.RemoveSkillProjectile(this);
    }

    public void OnAttacked()
    {
        if (_destroyIfAttacked)
            SkillManager.Instance.RemoveSkillProjectile(this);
    }

    private void SetAngle()
    {
        var angle = Vector2.Angle(_moveDirection, Vector2.right);
        angle *= (_moveDirection.y < 0f) ? -1f : 1f;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    private void Update()
    {
        if (_isRandomMoving && Time.time > _randomMoveDirectionTimer)
        {
            _randomMoveDirectionTimer = Time.time + 1f;
            _moveDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        }
        
        if (_isMoving)
        {
            if (_isRandomMoving)
            {
                transform.position = MapManager.Instance.GetPositionInsideMap(transform.position + _moveDirection.normalized * _moveSpeed * Time.deltaTime);
            }
            else
            {
                transform.position += _moveDirection.normalized * _moveSpeed * Time.deltaTime;
                if (!MapManager.Instance.IsPositionInsideMap(transform.position))
                {
                    SkillManager.Instance.RemoveSkillProjectile(this);
                }
            }
        }
    }
}
