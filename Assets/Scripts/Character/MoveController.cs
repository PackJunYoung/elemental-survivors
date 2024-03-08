using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    private float _speed;
    
    public void OnStart(float speed)
    {
        _speed = speed;
    }

    public void OnUpdate(float horizontal, float vertical)
    {
        var direction = new Vector3(horizontal, vertical, 0f);
        transform.position += direction * Time.deltaTime * _speed;
        
        if (horizontal != 0f)
        {
            transform.localScale = new Vector3(horizontal < 0f ? -1f : 1f, 1f, 1f);
        }
    }
}
