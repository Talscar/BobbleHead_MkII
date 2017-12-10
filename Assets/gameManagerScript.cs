using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManagerScript : MonoBehaviour {


    /// <summary>
    /// How many seconds we want the match to run.
    /// </summary>
    public float time_ToComplete = 60f;
    
    /// <summary>
    /// The time in which is a delay before starting
    /// </summary>
    public float time_TillStart = 4f; //Disable shaving tool till READY!
    
    /// <summary>
    /// Current time in the game.
    /// </summary>
    //public float time;

    /// <param name="time_TimetimeStart">When the match started!<param name="time_TimetimeStart"></param></param>
    public float time_TimetimeStart = 0; //When the game started

	void Start () {
        player = FindObjectOfType<PlayerScreenPointToClick>();
        player.DestroyBeard = false;
        if (button != null)
        {
            button.onClick.AddListener(gameStart);
        }
        //time += time_ToComplete + time_TillStart;
	}


    PlayerScreenPointToClick player;
    public UnityEngine.UI.Button button;
    public UnityEngine.UI.Text CountDown;
    public float thisTime;
    //bool canInteract;
    /// <summary>
    /// When the game starts, it processes a timer and calculates when the game start and initilizes player ability to interact with world objects or not.
    /// </summary>
    void gameStart()
    {
        time_TimetimeStart = Time.time;

        //time_TimetimeStart = time;
        //player.DestroyBeard = true;
        button.gameObject.SetActive(false);
        running = true;
    }

    bool running = false;
    /// <summary>
    /// When the game ends, it processes a timer and calculates the end game time to dissable the players ability to interact with the world objects.
    /// </summary>
    void gameEnd()
    {
        running = false;
        player.DestroyBeard = false;
        if(button != null)
        {
            button.gameObject.SetActive(true);
        }
    }
	// Update is called once per frame
	void Update () {
        thisTime = Time.time;
        if (running)
        {
            if (Time.time - (time_TillStart) < time_TimetimeStart)
            {
                float counter = time_TimetimeStart - (Time.time -  time_TillStart);
                if (CountDown != null && counter > -0.1)
                {
                    CountDown.text = "" + (int)counter + "...";
                }
            }
            else if (Time.time - (time_ToComplete + time_TillStart) < time_TimetimeStart)
            {
                CountDown.text = "";
                player.DestroyBeard = true;
            }
            else
            {
                gameEnd();
            }
        }
	}
}
