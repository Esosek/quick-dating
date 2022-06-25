using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private IntVariable scoreAsset = null;
    [SerializeField] private TextMeshProUGUI scoreText = null;

    void Start() => scoreAsset.Reset();


    public void UpdateUI ()
    {
        if(scoreText == null) {
            Debug.LogWarning("SCORE MANAGER: Score text reference not set");
            return;
        }
        else {
            scoreText.text = scoreAsset.Value.ToString("");
        }
    }
}
