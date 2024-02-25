using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    [SerializeField] private GameObject _mapSet;
    [SerializeField] private float _mapSetWidth;
    [SerializeField] private float _mapMinY;
    [SerializeField] private float _mapMaxY;

    private float _minLimitX;
    private float _maxLimitX;
    
    public static MapManager Instance { get; private set; }
    
    public void Init()
    {
        Instance = this;
        
        SetSubscribe();
    }

    private void SetSubscribe()
    {
        MessageBroker.Default.Receive<HeroEvent.OnMoveUpdate>().Subscribe(message =>
        {
            OnHeroMoveUpdate(message.Position);
        }).AddTo(gameObject);
    }

    private void OnHeroMoveUpdate(Vector3 position)
    {
        if (position.x < _minLimitX)
        {
            _minLimitX -= _mapSetWidth;
            GenerateMapSet(_minLimitX);
        }

        if (position.x > _maxLimitX)
        {
            _maxLimitX += _mapSetWidth;
            GenerateMapSet(_maxLimitX);
        }
    }

    private void GenerateMapSet(float x)
    {
        var newMapSet = Instantiate(_mapSet, transform);
        newMapSet.transform.localPosition = new Vector3(x, 0f, 0f);
    }

    private (float, float) GetCurrentLimitX()
    {
        var halfWidth = _mapSetWidth * 0.5f;
        var min = _minLimitX - halfWidth;
        var max = _maxLimitX + halfWidth;
        return (min, max);
    }
    
    public Vector3 GetPositionInsideMap(Vector3 position)
    {
        position.y = Mathf.Clamp(position.y, _mapMinY, _mapMaxY);
        return position;
    }

    public Vector3 GetRandomPositionInsideMap()
    {
        var (minLimitX, maxLimitX) = GetCurrentLimitX();
        var randomX = Random.Range(minLimitX, maxLimitX);
        var randomY = Random.Range(_mapMinY, _mapMaxY);
        return new Vector3(randomX, randomY, 0f);
    }

    public bool IsPositionInsideMap(Vector3 position)
    {
        var (minLimitX, maxLimitX) = GetCurrentLimitX();
        return position.x >= minLimitX && position.x <= maxLimitX && position.y >= _mapMinY && position.y <= _mapMaxY;
    }
}
