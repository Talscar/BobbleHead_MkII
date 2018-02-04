using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


//https://gamedevelopment.tutsplus.com/tutorials/how-to-save-and-load-your-players-progress-in-unity--cms-20934

//   http://wiki.unity3d.com/index.php?title=Saving_and_Loading_Data:_XmlSerializer

//https://unity3d.com/learn/tutorials/modules/beginner/live-training-archive/scriptable-objects

public class playerProfile: MonoBehaviour {

    //[System.Serializable]public struct m_profile
    //{
    //    [SerializeField]
    //    private int m_HighScore;
    //    [SerializeField]
    //    private string m_Username;
    //    [SerializeField]
    //    private int m_HairsCutSuccessfully;
    //    [SerializeField]
    //    private int m_HairsCutUnsuccessfully;
    //    [SerializeField]
    //    private int m_ScorePool;

    //    public int highScore
    //    {
    //        get { return m_HighScore; }
    //        set { m_HighScore = value; }
    //    }
    //    public string username
    //    {
    //        get { return m_Username; }
    //        set { m_Username = value; }
    //    }
    //    public int hairsCutSuccessfully
    //    {
    //        get { return m_HairsCutSuccessfully; }
    //        set { m_HairsCutSuccessfully = value; }
    //    }
    //    public int hairsCutUnsuccessfully
    //    {
    //        get { return m_HairsCutUnsuccessfully; }
    //        set { m_HairsCutUnsuccessfully = value; }
    //    }
    //    public int scorePool
    //    {
    //        get { return m_ScorePool; }
    //        set { m_ScorePool = value; }
    //    }
    //    //public m_profile(int highScore)
    //    //{
    //    //    m_HighScore = highScore;
    //    //}
    //}
    [SerializeField]public static List<PlayerScreenPointToClick.scoreKeeping> playersData = new List<PlayerScreenPointToClick.scoreKeeping>(1);
    [SerializeField]public List<PlayerScreenPointToClick.scoreKeeping> userData = new List<PlayerScreenPointToClick.scoreKeeping>(1);
    [SerializeField]public int profileLoaded = 0;
    [SerializeField]public PlayerScreenPointToClick.scoreKeeping usingPlayerData;

    public PlayerScreenPointToClick.scoreKeeping updateData(PlayerScreenPointToClick.scoreKeeping newData)
    {
        Debug.Log("Updating...");
        //playersData[profileLoaded].scorePool = newData.scorePool;
        //playersData[profileLoaded] = newData;
        if (userData.Count > 0)
        {
            //foreach(m_profile profile in playersData)
            //{

            //}
            int score = userData[profileLoaded].points + 5;

            //Creates a new Instance of playerData to be modified
            PlayerScreenPointToClick.scoreKeeping updateProfile = userData[profileLoaded];
            {//Open

                if(updateProfile.highScore < newData.highScore)
                    updateProfile.highScore = newData.highScore;
                if (newData.player_Name != "")
                {
                    updateProfile.player_Name = userData[profileLoaded].player_Name;
                }
                updateProfile.scorePool = userData[profileLoaded].scorePool + newData.highScore;


                updateProfile.Successful_hairsCut = userData[profileLoaded].Successful_hairsCut + newData.Successful_hairsCut;
                updateProfile.Unsuccessful_hairsCut = userData[profileLoaded].Unsuccessful_hairsCut + newData.Unsuccessful_hairsCut;
                newData.highScore = 0;
                newData.Successful_hairsCut = 0;
                newData.Unsuccessful_hairsCut = 0;
                newData.player_Name = "";
                newData.scorePool = 0;
            }//Close
            //Updates player Data
            userData[profileLoaded] = updateProfile;
            //playersData[profileLoaded].scorePool += newData.scorePool;
            newData.scorePool = 0;

        }
        saveProfiles();
        return newData;
    }

    //public void scoreRese

    public void saveProfiles()
    {
        Debug.Log("Saving...");
        //Create the file and push to file.
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerProfiles.dat");

        playerData data = new playerData();
        //data.m_ScorePool = playersData[profileLoaded].scorePool;
        Debug.LogError("INCOMPLETE Script!");
        //https://unity3d.com/learn/tutorials/topics/scripting/persistence-saving-and-loading-data
        //39:34


        bf.Serialize(file, data);
        file.Close();
        return;
    }
    public void loadProfiles()
    {
        Debug.Log("Loading...");
        //Load files and pulls data.
        if (File.Exists(Application.persistentDataPath + "/playerProfiles.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerProfiles.dat", FileMode.Open);
            playerData data = (playerData)bf.Deserialize(file);

            //data.m_ScorePool = playersData[profileLoaded].scorePool;
            //data.m_Username = playersData[profileLoaded].username;
            //playersData[profileLoaded].scorePool = data.m_ScorePool;
            //playersData[profileLoaded].username = data.m_Username;
            //playersData[profileLoaded] = updateData(new );
            PlayerScreenPointToClick.scoreKeeping thisData = new PlayerScreenPointToClick.scoreKeeping();
            thisData.player_Name = data.m_Username;
            thisData.scorePool = data.m_ScorePool;
            thisData.highScore = data.m_HighScore;
            usingPlayerData = thisData;


            //if (userData.Count > 0)
            //userData[0] = usingPlayerData;
            //else
            //{
            //    //userData = new List<PlayerScreenPointToClick.scoreKeeping>();
            Debug.LogError("Scorepool: " + thisData.scorePool);
            userData.Add(usingPlayerData);

            //}

            playersData = userData;
            ////Debug.Log("HELLO!!! " + data.m_Username);

            //playersData[profileLoaded] = thisData;

            file.Close();

        }
    }
    //public void loadProfiles()
    //{
    //    Debug.Log("Loading...");
    //    //Load files and pulls data.
    //    if(File.Exists(Application.persistentDataPath + "/playerProfiles.dat"))
    //    {
    //        BinaryFormatter bf = new BinaryFormatter();
    //        FileStream file = File.Open(Application.persistentDataPath + "/playerProfiles.dat", FileMode.Open);
    //        playerData data = (playerData)bf.Deserialize(file);
    //        file.Close();

    //    }
    //}


    public static playerProfile main;
    void Awake()
    {
        if(main == null)
        {
            DontDestroyOnLoad(gameObject);
            main = this;
        }
        else if(main != this)
        {
            Destroy(gameObject);
        }
        if(userData.Count == 0)
        {
            userData = new List<PlayerScreenPointToClick.scoreKeeping>(1);
        }
    }

    //void Start()
    //{
    //    if(playerData.Capacity < 1)
    //    {
    //        playerData.Add(new m_profile());
    //    }
    //    Debug.Log(playerData[0].hairsCutSuccessfully);
    //}
    //Save
    //Load
    //Delete

    ////////public static void saveProfile()
    ////////{
    ////////    playersData.Add(usingPlayerData);
    ////////    BinaryFormatter bf = new BinaryFormatter();
    ////////    FileStream file = File.Create(Application.persistentDataPath + "/savedgames.gd");
    ////////    bf.Serialize(file, playerProfile.playersData);
    ////////    file.Close();
    ////////}

    ////////public static void loadProfile()
    ////////{
    ////////    if (File.Exists(Application.persistentDataPath + "/savedGames.gd"))
    ////////    {
    ////////        BinaryFormatter bf = new BinaryFormatter();
    ////////        FileStream file = File.Open(Application.persistentDataPath + "/savedGames.gd", FileMode.Open);
    ////////        playerProfile.playersData = (List<m_profile>)bf.Deserialize(file);
    ////////        file.Close();
    ////////    }
    ////////}
    //public static void save()
    //    {
    //        savedgames.add(game.current);
    //        binaryformatter bf = new binaryformatter();
    //        filestream file = file.create(application.persistentdatapath + "/savedgames.gd");
    //        bf.serialize(file, saveload.savedgames);
    //        file.close();
    //    }


    //public static void Save()
    //    {
    //        savedGames.Add(Game.current);
    //        BinaryFormatter bf = new BinaryFormatter();
    //        FileStream file = File.Create(Application.persistentDataPath + "/savedGames.gd");
    //        bf.Serialize(file, SaveLoad.savedGames);
    //        file.Close();
    //    }

    //public static void Load()
    //    {
    //        if (File.Exists(Application.persistentDataPath + "/savedGames.gd"))
    //        {
    //            BinaryFormatter bf = new BinaryFormatter();
    //            FileStream file = File.Open(Application.persistentDataPath + "/savedGames.gd", FileMode.Open);
    //            SaveLoad.savedGames = (List<Game>)bf.Deserialize(file);
    //            file.Close();
    //        }
    //    }

}

[Serializable]
class playerData
{
    public int m_HighScore;
    public string m_Username;
    public int m_HairsCutSuccessfully;
    public int m_HairsCutUnsuccessfully;
    public int m_ScorePool;
}

/*
https://www.draw.io/?state=%7B%22ids%22:%5B%221zg-0sMN9QnTsfxQJQUy1l-2cyffzTjw1%22%5D,%22action%22:%22open%22,%22userId%22:%22113534453691376989721%22%7D#G1zg-0sMN9QnTsfxQJQUy1l-2cyffzTjw1

    https://www.google.com.au/search?q=unity+get+set&rlz=1C1ASUC_enAU615AU615&oq=unity+get+set&aqs=chrome..69i57j69i60j69i65l2j69i60l2.1679j0j7&sourceid=chrome&ie=UTF-8


    https://docs.google.com/document/d/1GEyxzYIy4Vif3opOUB5SR_qdsSnkp9YCFDmcNVPEjwM/edit#
    https://www.draw.io/?state=%7B%22ids%22:%5B%221zg-0sMN9QnTsfxQJQUy1l-2cyffzTjw1%22%5D,%22action%22:%22open%22,%22userId%22:%22113534453691376989721%22%7D#G1zg-0sMN9QnTsfxQJQUy1l-2cyffzTjw1
    https://docs.google.com/document/d/1sFIcEWpv68Jo5Cf0c0mmYcs4nJOC25y2FbT--_oJfqw/edit#heading=h.wjhih6y0fv7r
    https://docs.google.com/document/d/1H_Ik613By6bAxuNNmY-Q-kipA61RmE0VpPdzXrriN54/edit

    https://drive.google.com/drive/folders/1fmjwiKW8W3l-7iM0Hg0UMijLNh-rIJb8
    */
