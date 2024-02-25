using System.Collections;
using System.Collections.Generic;
using TMPro;
using UniRx;
using UnityEngine;

public class UiLevel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _levelText;
    public void Init()
    {
        SetSubscribe();
        Invalidate();
    }

    private void SetSubscribe()
    {
        MessageBroker.Default.Receive<UiEvent.InvalidateLevel>().Subscribe(_ =>
        {
            Invalidate();
        }).AddTo(gameObject);
    }

    private void Invalidate()
    {
        var level = HeroManager.Instance.GetCurrentLevel();
        _levelText.text = $"Lv. {level:00}";
    }
}
