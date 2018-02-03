using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[ExecuteInEditMode]
//public class returnMenu : MonoBehaviour
//{

//}

public class myMenuController : MonoBehaviour {
    [System.Serializable]
    public struct pageData
    {
        [SerializeField]
        public string pageName;
        [SerializeField]
        public GameObject pageObject;
    }

    [SerializeField]public pageData[] pages;
    [Tooltip("The working menu is the individual thing to activate and deactivate.")]
    //[SerializeField]public pageData parentMenu;
    public GameObject parentMenu;
    //[SerializeField]private int[] pageProgress;// = { 0 };
    [Tooltip("This is this Menu's menu to activate so this menu is visable.")]
    public GameObject thisMenu;

    /////
    //public GameObject myWorkingMenu;
    //public GameObject returnMenu;

    /*
    Takes a single menu. Activates a pages[] and deactivates its parent! Script per template_menu and _child
    */// OnInspectorGUI

    public void openMenu(string name)
    {
        pageData workingPage;
        workingPage.pageName = "";
        workingPage.pageObject = null;
        foreach(pageData thisPage in pages)
        {
            if(thisPage.pageName == name)
            {
                workingPage = thisPage;
                break;
            }
        }

        if(workingPage.pageName != null && workingPage.pageObject != null)
        {
            Debug.Log("Could do some fancy stuff later?");
            //parentMenu.pageObject.SetActive(false);
            workingPage.pageObject.SetActive(true);
            workingPage.pageObject.GetComponent<myMenuController>().actSelf(true);
            workingPage.pageObject.GetComponent<myMenuController>().isActiveMenu = true;
            isActiveMenu = false;
        }
        thisMenu.SetActive(false);
            return;
    }

    public void returnToMenu()
    {
        thisMenu.SetActive(false);
        if (parentMenu != null)
        {
            parentMenu.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
            Debug.LogWarning("You need a way to reopen this menu! use a button and actSelf(true) to reopen this things menu!");
        }

        if (parentMenu != null)
        {
            parentMenu.GetComponent<myMenuController>().actSelf(true);
            parentMenu.GetComponent<myMenuController>().isActiveMenu = true;
        }

        isActiveMenu = false;
    }

    public void actSelf(bool thisSwitch)
    {
        this.gameObject.SetActive(true);
        thisMenu.SetActive(thisSwitch);
        isActiveMenu = thisSwitch;
    }

    public bool isActiveMenu = false;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && isActiveMenu)
        {
            returnToMenu();
        }
    }

    //////////public void progressToThisMenu()
    //////////{
    //////////    //Automatically call function when button is pressed.
    //////////    //Once called... Close the menus and open the new ones.
    //////////}
    //////////public void returnToThisMenu()
    //////////{
    //////////    //Automatically call function when button is pressed.
    //////////}

    //////////public void actSelf()
    //////////{
    //////////    this.gameObject.SetActive(true);
    //////////    //Using own script to activate self.
    //////////}


    //////////public GameObject thisMenu;
    //////////public void activateMenu()
    //////////{
    //////////    if (thisMenu != null)
    //////////        thisMenu.SetActive(true);
    //////////    else
    //////////        gameObject.SetActive(true);
    //////////}
    //////////public void deactivateMenu()
    //////////{
    //////////    if (thisMenu != null)
    //////////        thisMenu.SetActive(false);
    //////////    else
    //////////        gameObject.SetActive(false);
    //////////}
    //[SerializeField]public void testing(GameObject jack, bool state)
    //{

    //}

}

//https://answers.unity.com/questions/1206632/trigger-event-on-variable-change.html