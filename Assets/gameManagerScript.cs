using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManagerScript : MonoBehaviour {

    public float time_ToComplete = 60f;
    public float time_TillStart = 5f; //Disable shaving tool till READY!
    public float time;
    float time_TimetimeStart = 0;

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<PlayerScreenPointToClick>();
        player.DestroyBeard = false;
        if (button != null)
        {
            button.onClick.AddListener(gameStart);
        }
	}


    PlayerScreenPointToClick player;
    public UnityEngine.UI.Button button;
    //bool canInteract;
    /// <summary>
    /// When the game starts, it processes a timer and calculates when the game start and initilizes player ability to interact with world objects or not.
    /// </summary>
    void gameStart()
    {
        time_TimetimeStart = Time.time;
        player.DestroyBeard = true;
        button.gameObject.SetActive(false);
    }
    /// <summary>
    /// When the game ends, it processes a timer and calculates the end game time to dissable the players ability to interact with the world objects.
    /// </summary>
    void gameEnd()
    {
        player.DestroyBeard = false;
        if(button != null)
        {
            button.gameObject.SetActive(true);
        }
    }
	// Update is called once per frame
	void Update () {

        if(time < time_ToComplete + time_TillStart)
        {
            time = Time.time - time_TimetimeStart;
        }
        else
        {
            gameEnd();
        }
	}
}
