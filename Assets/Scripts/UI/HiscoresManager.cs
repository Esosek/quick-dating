using UnityEngine;
using LootLocker.Requests;

public class HiscoresManager : MonoBehaviour
{
    [SerializeField] private IntVariable scoreVariable = null;
    [SerializeField] private StringVariable playerNameVariable = null;
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
        
        LootLockerSDKManager.SubmitScore(playerNameVariable.Value, scoreVariable.Value, leaderboardKey, (response) =>
        {
            if (response.statusCode == 200) {
                Debug.Log("Successful");
            } else {
                Debug.Log("failed: " + response.Error);
            }
        });
    }

    private void RetrieveScore()
    {
        LootLockerSDKManager.GetScoreList(leaderboardKey, 10, 0, (response) => 
        {
            if (response.statusCode == 200)
            {
                Debug.Log("HISCORES: Data retrieve successful");
                LootLockerLeaderboardMember[] scoreList = response.items;
            }
            else
            {
                Debug.Log("HISCORES: Data retrieve failed: " + response.Error);
            }
        });
    }
}
