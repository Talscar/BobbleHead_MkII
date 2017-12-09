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
    int highestNumericValue = 0;
    //int spare = 0;
    /// <summary>
    /// When called, it will verify the transforms that are children of this transform, and then process them for naming conventions. Return then repeat.
    /// </summary>
    void transformFilter()
    {
        Transform[] children = GetComponentsInChildren<Transform>();
        //int highestNumericValue = 0;

        //Filter all Transforms for Numerical transforms for highest numerical values.
        foreach (Transform child in children)
        {
            int nameNum = 0;
            int returning;
            bool returnable;

            string newNum = "";
            //Debug.LogError("Require research and assistance converting transform name to int number!");
            foreach (char testing in child.transform.name)
            {
                int tester = 0;
                //if(testing != int)
                if (char.IsNumber(testing))
                {
                    tester = int.Parse(testing + "");
                    newNum += testing;
                    //Debug.Log(testing);

                    nameNum = int.Parse(newNum);
                    if (nameNum > highestNumericValue)
                    {
                        highestNumericValue = nameNum;
                    }
                }




            }
            //nameNum = int.Parse(newNum);

            //bool result = int.TryParse(child.transform.name, out returning);
            //if(result)
            //{
            //    string reChildName = child.transform.name;
            //    if(reChildName.Contains("[stop]"))
            //    {
            //        reChildName.Replace("[stop]", "");
            //    }
            //    //string newInt = int.Parse(child.transform.name);
            //    Debug.Log(reChildName + " : " + child.transform.name + " : " + returning);
            //    Debug.Log(int.Parse(reChildName));
            //    nameNum = int.Parse(reChildName/*child.transform.name*/);
            //}

            ////ToString
            //int nameNum = int.TryParse(child.transform.name, out returning);
            if (nameNum > highestNumericValue)
                highestNumericValue = nameNum;
        }

        movePoints = new levelProgression[highestNumericValue + 1];
        highestNumericValue = 0;

        //Filter in all Transforms
        transformOrder = 0;
        foreach (Transform child in children)
        {
            int nameNum = 0;
            int returning;
            bool returnable;

            string newNum = "";
            //Debug.LogError("Require research and assistance converting transform name to int number!");
            foreach (char testing in child.transform.name)
            {
                int tester = 0;
                //if(testing != int)
                if (char.IsNumber(testing))
                {
                    tester = int.Parse(testing + "");
                    newNum += testing;
                    //Debug.Log(testing);

                    nameNum = int.Parse(newNum);
                    //if(returnTrueTransformOrder("hi"))
                    //{
                    //    Debug.LogWarning("Hello!");
                    //}
                    //Debug.LogError(transformOrder + " : " + tester);
                    if (tester == transformOrder)
                    {
                        highestNumericValue = nameNum;
                        movePoints[transformOrder].moveTo = child;
                        movePoints[transformOrder].toProcess = child.GetComponentInChildren<progressionReportSystem>();
                        if(movePoints[transformOrder].toProcess == null)
                        {
                            if(movePoints[transformOrder].moveTo.name.Contains("[stop]"))
                            {
                                movePoints[transformOrder].moveTo.name.Replace("[stop]", "");
                            }
                        }

                        transformOrder++;
                    }
                }
            }


            ////////////nameNum = int.Parse(child.transform.name);
            ////////////if (nameNum == i)
            ////////////{
            ////////////    children[highestNumericValue] = child;
            ////////////}
        }
    }

    int transformOrder = 0;
    /// <summary>
    /// Returns a value if the string sent is a number based on filtering values.
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    //bool returnTrueTransformOrder(string name)
    //{
    //    //get the string name. Process and check if it is a number. Check if it is == to the transform order number.
    //    if(name != "hi")
    //    {
    //        return false;
    //    }
    //    else
    //        return true;
    //}

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
