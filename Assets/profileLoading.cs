using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class profileLoading : MonoBehaviour {
    public string stringToEdit = "Username";
    public Rect newPosition;
    PlayerScreenPointToClick.scoreKeeping playerName;
    void OnGUI()
    {
        //https://docs.unity3d.com/ScriptReference/GUI.TextField.html
        stringToEdit = GUI.TextField(newPosition, stringToEdit, 25);
        playerName.player_Name = stringToEdit;
    }
    // Use this for initialization
    void Start () {
        playerName = FindObjectOfType<PlayerScreenPointToClick>().myScore;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
