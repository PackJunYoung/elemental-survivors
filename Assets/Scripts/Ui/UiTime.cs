using System.Collections;
using System.Collections.Generic;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.Serialization;

public class UiTime : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timeText;
    
    public void Init()
    {
        SetSubscribe();
        Invalidate();
    }

    private void SetSubscribe()
    {
        MessageBroker.Default.Receive<UiEvent.InvalidateTime>().Subscribe(_ =>
        {
            Invalidate();
        }).AddTo(gameObject);
    }

    private void Invalidate()
    {
        var elapsedSeconds = MainGameManager.Instance.GetGameData().GetElapsedTime();
        var minutes = Mathf.FloorToInt(elapsedSeconds / 60);
        var seconds = Mathf.FloorToInt(elapsedSeconds % 60);
        _timeText.text = $"{minutes:00}:{seconds:00}";
    }
}
