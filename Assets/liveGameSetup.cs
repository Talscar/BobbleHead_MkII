using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class liveGameSetup : MonoBehaviour {

    Transform mainCamera = null;

    [System.Serializable] public struct levelProgression
    {
        public Transform moveTo;
        public progressionReportSystem toProcess;
    }
    public levelProgression[] movePoints;
    int movePoints_Location = 0;

    [SerializeField] private progressionReportSystem[] toBeShavedFaceRig = null; 
	// Use this for initialization
	void Start ()
    {
        Transform[] children = GetComponentsInChildren<Transform>();
        mainCamera = Camera.main.gameObject.transform;

        transformFilter();
        //Transform[] stopPoints;
        //int i = 0;
        //int scripts = 0;
        //foreach (Transform child in children)
        //{
        //    if(child.name.Contains("[stop]"))
        //    {
        //        i++;
        //        progressionReportSystem test = child.GetComponentInChildren<progressionReportSystem>();
        //        if (test != null)
        //        {
        //            scripts++;
        //        }
        //    }
        //}
        //int countTransforms = GetComponentInChildren<Transform>().childCount;
        //Debug.Log(countTransforms);
        //stopPoints = new Transform[i];
        //toBeShavedFaceRig = new progressionReportSystem[scripts];
        //movePoints = new levelProgression[countTransforms];
        //i = 0;
        //scripts = 0;
        //foreach (Transform child in children)
        //{
        //    if (child != transform)
        //    {
        //        movePoints[i].moveTo = child;
        //        if (child.name.Contains("[stop]"))
        //        {
        //            stopPoints[i] = child;
        //            //i++;
        //            progressionReportSystem test = child.GetComponentInChildren<progressionReportSystem>();
        //            if (test != null)
        //            {
        //                toBeShavedFaceRig[scripts] = test;
        //                movePoints[i].toProcess = test;
        //                scripts++;
        //            }
        //        }
        //        i++;
        //    }
        //}

        mainTransform(movePoints[movePoints_Location].moveTo, false);
        //foreach


    }
	
    /// <summary>
    /// When called, it will verify the transforms that are children of this transform, and then process them for naming conventions. Return then repeat.
    /// </summary>
    void transformFilter()
    {
        Transform[] children = GetComponentsInChildren<Transform>();
        int highestNumericValue = 0;
        foreach(Transform child in children)
        {
            int nameNum = 0;
            int returning;
            bool returnable;
            Debug.LogError("Require research and assistance converting transform name to int number!");
            bool result = int.TryParse(child.transform.name, out returning);
            if(result)
            {
                nameNum = int.Parse(child.transform.name);
            }
            //int nameNum = int.TryParse(child.transform.name, out returning);
            if (nameNum > highestNumericValue)
                highestNumericValue = nameNum;
        }

        movePoints = new levelProgression[highestNumericValue];
        highestNumericValue = 0;

        int i = 0;
        foreach (Transform child in children)
        {
            int nameNum = int.Parse(child.transform.name);
            if(nameNum == i)
            {
                children[highestNumericValue] = child;
            }
        }
    }

    void filterRecursion()
    {

    }
    /// <summary>
    /// Feeds a new location for the main camera to automatically lerp or teleport to on start.
    /// </summary>
    /// <param name="newLocation"></param>
    void mainTransform(Transform newLocation, bool usingLerp)
    {
        if(usingLerp)
        {

        }
        else
        {
        mainCamera.position = newLocation.position;
        mainCamera.eulerAngles = newLocation.eulerAngles;
        }

    }
	// Update is called once per frame
	void Update () {
		
	}
}
