using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuManager : MonoBehaviour {

    [System.Serializable]
    public struct pageData
    {
        [SerializeField] public string pageName;
        [SerializeField] GameObject pageObject;
        [SerializeField] public pageData[] pages;
    }
    public pageData pages;
    public int[] pageProgress;


    //Depth
    //Length

        //1, 2, 3, Depth
        //2
        //3
        //Length
        //
        /*
        newData = pageProgress;
        [] = {0, 1, 2, 3, Depth}
              ^  ^  ^  ^  ^
              0      
              1
              2
              3
              Length
    */
        //
        [SerializeField]public void basicMenuFunction(GameObject ActivateMenu, GameObject DissableMenu)
    {
        if(ActivateMenu != null)
        ActivateMenu.SetActive(true);
        if(DissableMenu != null)
        DissableMenu.SetActive(false);

    }

    public void progressToPage(int nextPage)
    {
        int[] newData = new int[pageProgress.Length + 1];

        Debug.Log("Deactivate Old Page");
        //int[] newData = new int[pageProgress.Length];
        for (int i = 0; i < pageProgress.Length; i++)
        {
            newData[i] = pageProgress[i];
        }
        newData[newData.Length] = nextPage;
        pageProgress = newData;


        Debug.Log("activate new page");
        //To get to the next page, we need to travese the pages tree using the int values to access the page we desire.
    }

    public void returnToPreviousPage()
    {
        //pages[pag]
        int[] newData = new int[pageProgress.Length - 1];
        for (int i = 0; i < newData.Length; i++)
        {
            newData[i] = pageProgress[i];
        }
        pageProgress = newData;
    }
    public void closeMenu()
    {
        pageProgress = new int[] { };
    }


    ////////////////////////////////////////bool deityRecognized = false;
    ////////////////////////////////////////GameObject deity;
    ////////////////////////////////////////void playersCheck()
    ////////////////////////////////////////{
    ////////////////////////////////////////    GameObject[] players = GameObject.FindGameObjectsWithTag("player");
    ////////////////////////////////////////    foreach(GameObject player in players)
    ////////////////////////////////////////    {
    ////////////////////////////////////////        if(player.tag == "creator")
    ////////////////////////////////////////        {
    ////////////////////////////////////////            player = deity;
    ////////////////////////////////////////            if(!deityRecognized)
    ////////////////////////////////////////            {
    ////////////////////////////////////////                print("Your creator has awoken... No be good little creations!");
    ////////////////////////////////////////            }
    ////////////////////////////////////////        }
    ////////////////////////////////////////    }
    ////////////////////////////////////////}
    //////GameObject returnPageItem()
    //////{

    //////    return;
    //////}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
