using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


//https://gamedevelopment.tutsplus.com/tutorials/how-to-save-and-load-your-players-progress-in-unity--cms-20934
public static class playerProfile { //: MonoBehaviour {

    [System.Serializable]public struct m_profile
    {
        private int m_HighScore;
        private string m_Username;
        private int m_HairsCutSuccessfully;
        private int m_HairsCutUnsuccessfully;
        private int m_ScorePool;

        public int highScore
        {
            get { return m_HighScore; }
            set { m_HighScore = value; }
        }
        public string username
        {
            get { return m_Username; }
            set { m_Username = value; }
        }
        public int hairsCutSuccessfully
        {
            get { return m_HairsCutSuccessfully; }
            set { m_HairsCutSuccessfully = value; }
        }
        public int hairsCutUnsuccessfully
        {
            get { return m_HairsCutUnsuccessfully; }
            set { m_HairsCutUnsuccessfully = value; }
        }
        public int scorePool
        {
            get { return m_ScorePool; }
            set { m_ScorePool = value; }
        }
    }
    public static List<m_profile> playerData = new List<m_profile>(1);
    public static m_profile usingPlayerData;

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

    public static void saveProfile()
    {
        playerData.Add(usingPlayerData);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/savedgames.gd");
        bf.Serialize(file, playerProfile.playerData);
        file.Close();
    }

    public static void loadProfile()
    {
        if (File.Exists(Application.persistentDataPath + "/savedGames.gd"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/savedGames.gd", FileMode.Open);
            playerProfile.playerData = (List<m_profile>)bf.Deserialize(file);
            file.Close();
        }
    }
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


/*
https://www.draw.io/?state=%7B%22ids%22:%5B%221zg-0sMN9QnTsfxQJQUy1l-2cyffzTjw1%22%5D,%22action%22:%22open%22,%22userId%22:%22113534453691376989721%22%7D#G1zg-0sMN9QnTsfxQJQUy1l-2cyffzTjw1

    https://www.google.com.au/search?q=unity+get+set&rlz=1C1ASUC_enAU615AU615&oq=unity+get+set&aqs=chrome..69i57j69i60j69i65l2j69i60l2.1679j0j7&sourceid=chrome&ie=UTF-8


    https://docs.google.com/document/d/1GEyxzYIy4Vif3opOUB5SR_qdsSnkp9YCFDmcNVPEjwM/edit#
    https://www.draw.io/?state=%7B%22ids%22:%5B%221zg-0sMN9QnTsfxQJQUy1l-2cyffzTjw1%22%5D,%22action%22:%22open%22,%22userId%22:%22113534453691376989721%22%7D#G1zg-0sMN9QnTsfxQJQUy1l-2cyffzTjw1
    https://docs.google.com/document/d/1sFIcEWpv68Jo5Cf0c0mmYcs4nJOC25y2FbT--_oJfqw/edit#heading=h.wjhih6y0fv7r
    https://docs.google.com/document/d/1H_Ik613By6bAxuNNmY-Q-kipA61RmE0VpPdzXrriN54/edit

    https://drive.google.com/drive/folders/1fmjwiKW8W3l-7iM0Hg0UMijLNh-rIJb8
    */
