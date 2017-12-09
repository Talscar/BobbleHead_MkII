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

        Transform[] stopPoints;
        int i = 0;
        int scripts = 0;
        foreach (Transform child in children)
        {
            if(child.name.Contains("[stop]"))
            {
                i++;
                progressionReportSystem test = child.GetComponentInChildren<progressionReportSystem>();
                if (test != null)
                {
                    scripts++;
                }
            }
        }
        stopPoints = new Transform[i];
        toBeShavedFaceRig = new progressionReportSystem[scripts];
        i = 0;
        scripts = 0;
        foreach (Transform child in children)
        {
            if (child.name.Contains("[stop]"))
            {
                stopPoints[i] = child;
                i++;
                progressionReportSystem test = child.GetComponentInChildren<progressionReportSystem>();
                if (test != null)
                {
                    toBeShavedFaceRig[scripts] = test;
                    scripts++;
                }
            }
        }

        mainTransform(movePoints[movePoints_Location].moveTo, false);
        //foreach


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
