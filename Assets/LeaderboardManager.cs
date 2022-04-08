using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
public class LeaderboardManager : MonoBehaviour
{
    public Text[] entries;

    private void Start()
    {

        string playerIdentifier = "unique_player_identifier_here";
        LootLockerSDKManager.StartSession(playerIdentifier, (response) =>
        {
            if (response.success)
            {
                Debug.Log("Successful");
            }
            else
            {
                Debug.LogWarning("failed: " + response.Error);
            }
        });
    }

    public void FetchScores()
    {
        LootLockerSDKManager.GetScoreList(2295, 15, (response) =>
        {
            if (response.success)
            {
                LootLockerLeaderboardMember[] scores = response.items;

                for (int i = 0; i < scores.Length; i++)
                {
                    entries[i].text = (scores[i].rank + ".  " + scores[i].member_id + " - " + scores[i].score);
                }

                if (scores.Length < 15)
                {
                    for (int i = scores.Length; i < 15; i++)
                    {
                        entries[i].text = (i + 1).ToString() + ".  none";
                    }
                }
            }
            else
            {
                Debug.LogWarning("failed: " + response.Error);
            }
        });
    }

    public void SubmitScore()
    {

        LootLockerSDKManager.SubmitScore("Jose", 34, 2295, (response) =>
        {
            if (response.success)
            {
                Debug.Log("Score sent successfully.");
            }
            else
            {
                Debug.LogWarning("Score failed to send. " + response.Error);
            }
        });
    }
}

*/