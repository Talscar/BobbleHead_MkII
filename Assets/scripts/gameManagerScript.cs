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

	void Awake () {
        DontDestroyOnLoad(gameObject);
        player = FindObjectOfType<PlayerScreenPointToClick>();
        player.DestroyBeard = false;
        if (StartGame_Button != null)
        {
            StartGame_Button.onClick.AddListener(gameStart);
        }
        Menu.GetComponent<myMenuController>().actSelf(true);
        menuItemsSwitch(true);
        //time += time_ToComplete + time_TillStart;
    }


    PlayerScreenPointToClick player;
    public UnityEngine.UI.Button StartGame_Button;
    public UnityEngine.UI.Text CountDown;
    public float thisTime;

    private liveGameSetup thisSceneGameSetup_Transforms_Cams;
    public void returnLiveGameSetup(liveGameSetup thisLiveGameSetup)
    {
        thisSceneGameSetup_Transforms_Cams = thisLiveGameSetup;
        return;
    }

    //bool canInteract;
    /// <summary>
    /// When the game starts, it processes a timer and calculates when the game start and initilizes player ability to interact with world objects or not.
    /// </summary>
    void gameStart()
    {
        Menu.GetComponent<myMenuController>().actSelf(false);
        menuItemsSwitch(false);
        time_TimetimeStart = Time.time;

        //time_TimetimeStart = time;
        //player.DestroyBeard = true;
        StartGame_Button.gameObject.SetActive(false);
        running = true;
    }

    [SerializeField]public static bool running = false;

    //live
    //liveGameSetup thisSetup;
    //public liveGameSetup currentRig()
    //{

    //}

    void menuItemsSwitch(bool switching)
    {
        foreach (GameObject item in menuItems)
        {
            item.SetActive(switching);
        }
        return;
    }

    /// <summary>
    /// When the game ends, it processes a timer and calculates the end game time to dissable the players ability to interact with the world objects.
    /// </summary>
    void gameEnd()
    {
        Menu.GetComponent<myMenuController>().actSelf(true);
        menuItemsSwitch(true);

        running = false;
        player.DestroyBeard = false;
        if(StartGame_Button != null)
        {
            StartGame_Button.gameObject.SetActive(true);
        }
        playerProfile.m_profile thisData = new playerProfile.m_profile();
        {
            thisData.highScore = player.myScore.points;
            thisData.username = player.myScore.player_Name;
            thisData.hairsCutSuccessfully = player.myScore.Successful_hairsCut;
            thisData.hairsCutUnsuccessfully = player.myScore.Unsuccessful_hairsCut;
        }
        //thisData.scorePool = pl
        playerProfile.main.updateData(thisData);
        player.myScore.points = 0; //thisData.highScore;
        //thisData.username = player.myScore.player_Name;
        player.myScore.Successful_hairsCut = 0;//thisData.hairsCutSuccessfully;
        player.myScore.Unsuccessful_hairsCut = 0;// thisData.hairsCutUnsuccessfully;
        //player.c
        thisSceneGameSetup_Transforms_Cams.headCompleted();
        player.myScore.facesDone = 0;
        //player.nextHead(false);
        Debug.Log("Score Resets.");
        //Menu.SetActive(true);
    }
    // Update is called once per frame
    public GameObject Menu;
    public GameObject[] menuItems;
        //*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*

    ////////////public delegate void functionList();
    ////////////public static event functionList OnCall;
    //public static functionList modularFunction;//List<functionList> modularFunction = new List<functionList>();
    //void OnGUI()
    //{
    //    if(GUI.Button(new Rect(Screen.width / 2 - 50, 5, 100, 30), "Click"))
    //    {
    //        if(OnClicked != null)
    //        {
    //            OnClicked();
    //        }
    //    }
    //}
    //[SerializeField] public functionList modularFunction;

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
