using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private FloatVariable timeAsset = null;
    [SerializeField] private GameObject timerText = null;
    [SerializeField] private GameEvent onTimesUpEvent = null;

    private void Start() {
        timeAsset.Set(180f);
    }

    void Update()
    {   if(timeAsset == null) return;
        timeAsset.Set(timeAsset.Value - Time.deltaTime);
        int minutes = Mathf.FloorToInt(timeAsset.Value / 60f);
        int seconds = Mathf.FloorToInt(timeAsset.Value - minutes * 60);
        string niceTime = string.Format("{0:0}:{1:00}", minutes, seconds);

        timerText.GetComponent<TextMeshProUGUI>().text = niceTime;

        if(timeAsset.Value <= 0 && onTimesUpEvent != null) {
            onTimesUpEvent.Raise();
        }
    }
}
