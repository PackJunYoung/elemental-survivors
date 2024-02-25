using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class UiHp : MonoBehaviour
{
    [SerializeField] private Image _hpGauge;

    public void Init()
    {
        SetSubscribe();
        Invalidate();
    }

    private void SetSubscribe()
    {
        MessageBroker.Default.Receive<UiEvent.InvalidateHp>().Subscribe(_ =>
        {
            Invalidate();
        }).AddTo(gameObject);
    }

    private void Invalidate()
    {
        _hpGauge.fillAmount = HeroManager.Instance.GetHpRatio();
    }
}
