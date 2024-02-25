using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    private float _speed;
    private Vector3 _direction;

    public void Init(float speed)
    {
        _speed = speed;
    }
    
    public void OnUpdate(float horizontal, float vertical)
    {
        _direction = new Vector2(horizontal, vertical);
        var position = transform.position + _direction * Time.deltaTime * _speed;
        transform.position = MapManager.Instance.GetPositionInsideMap(position);

        if (horizontal != 0f)
        {
            transform.localScale = new Vector3(horizontal < 0f ? -1f : 1f, 1f, 1f);
        }
    }

    public Vector3 GetDirection()
    {
        return _direction.normalized;
    }
}
