using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class leaderboard_Load : MonoBehaviour {

	public Text scorePreview;
    // Use this for initialization
	void Start ()
    {
        List<playerProfile.m_profile> dataItems = playerProfile.playersData;

        Debug.LogError("Leaderboard loading and previewing required!");

        //https://unity3d.com/learn/tutorials/topics/user-interface-ui/scroll-view
        //https://unity3d.com/learn/tutorials/modules/beginner/ui/ui-scroll-rect
    }

    List<playerProfile.m_profile> sortData(List<playerProfile.m_profile> dataInput)
    {
        List<playerProfile.m_profile> newData = new List<playerProfile.m_profile>(dataInput);

        return newData;
    }
	// Update is called once per frame
	void Update () {
		
	}
}
