using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuManager : MonoBehaviour {

    [System.Serializable]
    public struct pageData
    {
        [SerializeField] public string pageName;
        [SerializeField] public GameObject pageObject;
        [SerializeField] public pageData[] pages;
    }
    public pageData[] pages;
    [SerializeField] private int[] pageProgress;// = { 0 };


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
    //    [SerializeField]public void basicMenuFunction(GameObject ActivateMenu, GameObject DissableMenu)
    //{
    //    if(ActivateMenu != null)
    //    ActivateMenu.SetActive(true);
    //    if (DissableMenu != null)
    //        DissableMenu.SetActive(false);

    //}
    //pages[0].pages[1].pages[3]
    pageData recursedPage(int[] inputData)
    {
        ////////////////////////////////////////////////pageData[] newSelections = pages.pages;
        ////////////////////////////////////////////////pageData newPage;// = recursedPage(inputData);
        pageData[] newSelections = pages;
        //pageData newPage;// = recursedPage(inputData);

        //foreach depth in this thing
        //get the new depth. Find the new location.
        //return until the depth is met at that length

        //Depth is how many things within a thing
        //Length is how many things in an array
        for (int i = 0; i < inputData.Length; i++)
        {
            //Debug.Log();
            newSelections = newSelections[inputData[i]].pages;
            //newPage = pages[i];
        }
        Debug.Log("NewSelections DATA: - " + newSelections.Length);
 
        Debug.Log("InputData.Length beach = " + inputData.Length + " : " + inputData[inputData.Length - 1] + " - "+ inputData[0]);
        return newSelections[inputData[0]];//new pageData();
    }

    public void progressToPage(int nextPage)
    {
        ///METHOD: recursedPage
        //pageProgress[nextPage - 1].p
        int[] newData;// = new int[pageProgress.Length];
        if (pageProgress.Length > 0)
        {
            newData = new int[1];
            newData[0] = nextPage;
            pageProgress = newData;
        }
        else
        {
            newData = new int[pageProgress.Length + 1];
            newData[pageProgress.Length - 1] = nextPage;
        }  
        pageData thisData = recursedPage(newData);
        thisData.pageObject.SetActive(false);
        Debug.Log("Deactivate Old Page - " + thisData.pageObject.name);
        newData = new int[pageProgress.Length + 1];
        thisData = recursedPage(newData);
        //newData = new int[pageProgress.Length + 1];
        //thisData = recursedPage(newData);
        //int[] newData = new int[pageProgress.Length];
        for (int i = 0; i < pageProgress.Length; i++)
        {
            newData[i] = pageProgress[i];
        }
        newData[newData.Length - 1] = nextPage;
        pageProgress = newData;

        thisData = recursedPage(pageProgress);
        thisData.pageObject.SetActive(true);
        Debug.Log("activate new page");
        //To get to the next page, we need to travese the pages tree using the int values to access the page we desire.
    }

    public void returnToPreviousPage()
    {
        ///METHOD: recursedPage
        //pageProgress[nextPage - 1].p
        int[] newData = new int[pageProgress.Length];
        pageData thisData = recursedPage(newData);
        thisData.pageObject.SetActive(false);
        Debug.Log("Deactivate Old Page - " + thisData.pageObject.name);
        newData = new int[pageProgress.Length - 1];
        thisData = recursedPage(newData);
        //newData = new int[pageProgress.Length + 1];
        //thisData = recursedPage(newData);
        //int[] newData = new int[pageProgress.Length];
        for (int i = 0; i < newData.Length; i++)
        {
            newData[i] = pageProgress[i];
        }
        //newData[newData.Length - 1] = nextPage;
        pageProgress = newData;

        thisData = recursedPage(pageProgress);
        thisData.pageObject.SetActive(true);
        Debug.Log("activate new page");
        //////////pages[pag]
        ////////int[] newData = new int[pageProgress.Length - 1];
        ////////for (int i = 0; i < newData.Length; i++)
        ////////{
        ////////    newData[i] = pageProgress[i];
        ////////}
        ////////pageProgress = newData;
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
