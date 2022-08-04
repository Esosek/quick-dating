using UnityEngine;
using LootLocker.Requests;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;
using TMPro;

public class HiscoresManager : MonoBehaviour
{
    [SerializeField] private IntVariable scoreVariable = null;
    [SerializeField] private StringVariable playerNameVariable = null;
    [SerializeField] private TextMeshProUGUI[] leaderboardPlayerNames = null;
    [SerializeField] private TextMeshProUGUI[] leaderboardPlayerScores = null;
    [SerializeField] private GameObject resetButton, submitButton, nameInputButton = null;
    [SerializeField] private TMP_InputField nameInputText = null;


    private const string leaderboardKey = "global_hiscores";
    // set default name == Nameless Lover

    // Start is called before the first frame update
    void Start()
    {
        StartSession();

        if(scoreVariable == null) Debug.LogWarning("HISCORES: Score variable reference not found!");
        if(playerNameVariable == null) Debug.LogWarning("HISCORES: Player name variable reference not found!");
    }

    private void StartSession()
    {
        LootLockerSDKManager.StartGuestSession((response) =>
        {
            if (!response.success)
            {
                Debug.Log("Error starting LootLocker session");

                return;
            }
            Debug.Log("Successfully started LootLocker session");
        });
    }

    public void SubmitScore() // called from SubmitScore event
    {
        if(scoreVariable == null || playerNameVariable == null) return; // null check

        // read and store player name
        if(nameInputText.text == "") playerNameVariable.SetValue("Unknown Lover");
        else playerNameVariable.SetValue(nameInputText.text);
        
        LootLockerSDKManager.SubmitScore(playerNameVariable.Value, scoreVariable.Value, leaderboardKey, (response) =>
        {
            if (response.statusCode == 200) {
                Debug.Log("HISCORES: Score submit successful");
                RetrieveScore();
                HideScoreForm();
            } else {
                Debug.Log("HISCORES: Score submit failed: " + response.Error);
            }
        });
    }

    public void RetrieveScore() // called from OnTimesUp event and after submitting score
    {
        LootLockerSDKManager.GetScoreList(leaderboardKey, 10, 0, (response) => 
        {
            if (response.statusCode == 200)
            {
                Debug.Log("HISCORES: Data retrieve successful");
                FillScoreRecords(response.items);
            }
            else
            {
                Debug.Log("HISCORES: Data retrieve failed: " + response.Error);
            }
        });
    }

    private void FillScoreRecords(LootLockerLeaderboardMember[] scoreList) 
    {
        int _numberOfRecords = 0;

        if(scoreList.Length > leaderboardPlayerNames.Length) {
            _numberOfRecords = leaderboardPlayerNames.Length;
        }
        else _numberOfRecords = scoreList.Length;

        for (int i = 0; i < _numberOfRecords; i++)
        {
            leaderboardPlayerNames[i].text = scoreList[i].member_id;
            leaderboardPlayerScores[i].text = scoreList[i].score.ToString();
        }
    }

    private void HideScoreForm()
    {
        resetButton.SetActive(true);
        nameInputButton.SetActive(false);
        submitButton.SetActive(false);
    }
}
