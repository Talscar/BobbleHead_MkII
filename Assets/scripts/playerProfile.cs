using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerProfile : MonoBehaviour {

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
