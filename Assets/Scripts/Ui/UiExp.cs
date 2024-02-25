using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class UiExp : MonoBehaviour
{
    [SerializeField] private Slider _expSlider;

    public void Init()
    {
        SetSubscribe();
        Invalidate();
    }
    
    private void SetSubscribe()
    {
        MessageBroker.Default.Receive<UiEvent.InvalidateExp>().Subscribe(_ =>
        {
            Invalidate();
        }).AddTo(gameObject);
    }

    private void Invalidate()
    {
        _expSlider.value = HeroManager.Instance.GetExpRatio();
    }
}
