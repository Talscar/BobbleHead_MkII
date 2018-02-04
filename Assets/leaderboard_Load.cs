using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class leaderboard_Load : MonoBehaviour {

	public Text scorePreview;
    // Use this for initialization
	void OnEnable ()
    {
        Debug.LogError(playerProfile.playersData.Count + " Is counted");
        List<PlayerScreenPointToClick.scoreKeeping> dataItems = playerProfile.playersData;
        if (scorePreview != null)
        {
            int i = 1;
            scorePreview.text = "";
            foreach (PlayerScreenPointToClick.scoreKeeping data in dataItems)
            {
                scorePreview.text += i + "   " + data.player_Name + "   " + data.scorePool + "\n";
                    i++;
                Debug.Log("ADDING TOO LEADERBOARD!");
//scores: place, player, score
            }
        }
        Debug.LogError("Leaderboard loading and previewing required!");

        //https://unity3d.com/learn/tutorials/topics/user-interface-ui/scroll-view
        //https://unity3d.com/learn/tutorials/modules/beginner/ui/ui-scroll-rect
    }

    List<PlayerScreenPointToClick.scoreKeeping> sortData(List<PlayerScreenPointToClick.scoreKeeping> dataInput)
    {
        List<PlayerScreenPointToClick.scoreKeeping> newData = new List<PlayerScreenPointToClick.scoreKeeping>(dataInput);

        return newData;
    }
	// Update is called once per frame
	void Update () {
		
	}
}
