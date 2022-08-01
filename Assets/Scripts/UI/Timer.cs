using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private FloatVariable timeAsset = null;
    [SerializeField] private GameConfig config = null;
    [SerializeField] private GameObject timerText = null;
    [SerializeField] private BoolVariable gameActiveState = null;
    [SerializeField] private GameEvent onTimesUpEvent = null;

    private void Start() {
        if(config != null) timeAsset.Set(config.Timer);
        else timeAsset.Set(180f); //set default if no config found

        if(gameActiveState == null) Debug.LogWarning("TIMER: Missing game active state reference");
    }

    void Update()
    {   
        if(timeAsset == null) return;
        if(gameActiveState != null && !gameActiveState.IsActive) return;

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
