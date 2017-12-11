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
    public int highestNumericValue = 0;
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
                    int newSelection = returnNewTransform(children, transformOrder);
                    if (newSelection >= 0)

                        ///<Info: FOLLOWING line of code prevents filtering correctly all Transforms.
                        /// It also prevents having more than 0 - 9 transforms thus now allowing us to have 10 or more 10+!
                        //if (tester == transformOrder)
                        {
                            //Debug.LogError("Return a new transform - to gain functionality. 10+ Transforms accessible. - " + newSelection );
                            //returnNewTransform();
                            highestNumericValue = nameNum;

                            ///Replaced children[transformOrder] with children[newSelection]
                            movePoints[transformOrder].moveTo = children[newSelection];
                            movePoints[transformOrder].toProcess = children[newSelection].GetComponentInChildren<progressionReportSystem>();
                            if (movePoints[transformOrder].toProcess == null)
                            {
                                if (movePoints[transformOrder].moveTo.name.Contains("[stop]"))
                                {
                                    movePoints[transformOrder].moveTo.name.Replace("[stop]", "");
                                }
                            }

                            transformOrder++;
                        }
                }
            }


            /////
            //if (returnNewTransform(children, transformOrder) != null)
            //{
            //    Debug.LogError("Return a new transform - to gain functionality. 10+ Transforms accessible.");
            //    //returnNewTransform();
            //    highestNumericValue = nameNum;
            //    movePoints[transformOrder].moveTo = child;
            //    movePoints[transformOrder].toProcess = child.GetComponentInChildren<progressionReportSystem>();
            //    if (movePoints[transformOrder].toProcess == null)
            //    {
            //        if (movePoints[transformOrder].moveTo.name.Contains("[stop]"))
            //        {
            //            movePoints[transformOrder].moveTo.name.Replace("[stop]", "");
            //        }
            //    }


            //    ////////////nameNum = int.Parse(child.transform.name);
            ////////////if (nameNum == i)
            ////////////{
            ////////////    children[highestNumericValue] = child;
            ////////////}
        }
        }

    int returnNewTransform(Transform[] transforms, int findMe)
    {

        //int returning;
        //bool returnable;

        //
        ////int nameNum = 0;
        ////int returning;
        ////bool returnable;

        ////string newNum = "";
        //////Debug.LogError("Require research and assistance converting transform name to int number!");
        ////foreach (char testing in child.transform.name)
        ////{
        ////    int tester = 0;
        ////    //if(testing != int)
        ////    if (char.IsNumber(testing))
        ////    {
        ////        tester = int.Parse(testing + "");
        ////        newNum += testing;
        ////        //Debug.Log(testing);

        ////        nameNum = int.Parse(newNum);
        ////        if (nameNum > highestNumericValue)
        ////        {
        ////            highestNumericValue = nameNum;
        ////        }
        ////    }




        ////}
        //
        int ic = 0;
        foreach (Transform child in transforms)
        {
        string newNum = "";
        int nameNum = 0;
            foreach (char testing in child.transform.name)
            {
                    //int tester = 0;
                //int tester = 0;
                //if(testing != int)
                if (char.IsNumber(testing))
                {
                    //tester = int.Parse(testing + "");
                    newNum += testing;
                    //Debug.Log(testing);

                    nameNum = int.Parse(newNum);
                    if (nameNum > highestNumericValue)
                    {
                        highestNumericValue = nameNum;
                    }
                }
                //tester = int.Parse(testing + "");
                    //newNum += testing;
                    //Debug.Log(testing);

                    //nameNum = int.Parse(newNum);



            }
            Debug.LogError("Check agaisnt highest numerical value based on slots and values itself.");
            //highestNumericValue
            if (newNum != "")
            {
                //if(newNum.try)
                //Debug.Log("ISSUES: " + newNum + " : " + nameNum);
                nameNum = int.Parse(newNum);
                if (findMe == nameNum/*testing*/)
                {
                    return ic;
                }
            }
            ic++;
        }
        return -1;
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

    /// <summary>
    /// When my current FaceBobble_Relocator target is shaved or skipped... Function activates to inform this script its time to move to the next target!
    /// </summary>
    public void nextTarget()
    {
        nextPosition = true;
        preClick = true;
    }
        /// <summary>
        /// 
        /// </summary>
    void transformCamera()
    {
        //if (movePoints.Length < currentTransform)
        //{
        //    currentTransform = 0;
        //}

        if (MoveAtTime < Time.time)
        {
            if (preClick)
            {
                MoveAtTime = Time.time + timeSpeedDelayVariblesBetweenTransitions;
                preClick = false;
            }
            if (positionCamera) //Time speed delay variables
            {

                mainCamera.position = Vector3.Lerp(mainCamera.position, movePoints[currentTransform].moveTo.position, travelSpeedOverTime);
                float distance = Vector3.Distance(mainCamera.position, movePoints[currentTransform].moveTo.position);
                if (distance < distanceSensitivity)
                {
                    positionCamera = false;
                    rotateCamera = true;
                    MoveAtTime = Time.time + timeSpeedDelayVariblesBetweenTransitions;
                }
            }
            else if (rotateCamera) //Time speed delay variables
            {
                mainCamera.eulerAngles = Vector3.Lerp(mainCamera.eulerAngles, movePoints[currentTransform].moveTo.eulerAngles, travelSpeedOverTime);
                float distance = Vector3.Distance(mainCamera.eulerAngles, movePoints[currentTransform].moveTo.eulerAngles);
                if (distance < distanceSensitivity)
                {
                    //positionCamera = false;
                    rotateCamera = false;
                    MoveAtTime = Time.time + timeSpeedDelayVariblesBetweenTransitions;
                }
            }
        }
        else if(!positionCamera && !rotateCamera && nextPosition)
        {
            //if(movePoints[currentTransform].toProcess != null)
            //Test for stop on thing!
            Debug.Log("Requires Filter and logic loops.");
            if(movePoints[currentTransform].toProcess != null)
            {
                nextPosition = false;
                //movePoints[currentTransform + 1]
                //stop moving, reactivate the sissors and get chopping!
            }


            positionCamera = true;
            //currentTransform++;
            //Filter name continue finding new positions or stop!
            if (movePoints.Length > currentTransform + 1)
            {
                if (movePoints[currentTransform + 1].moveTo != null)
                {
                    currentTransform++;
                }
                else
                    currentTransform = 0;
            }
            else
                currentTransform = 0;


            //else
            //{
            //    currentTransform = 0;
            //}
            //if()
        }


    }

    [Header("Camera transform tuning tools")]
    public float travelSpeedOverTime = 0.2f;
    public float distanceSensitivity = 0.3f;
    public float timeSpeedDelayVariblesBetweenTransitions = 1.6f;
    [SerializeField] private float MoveAtTime = 0;
    [Header("To be Private variables")]
    public bool nextPosition = false;
    public bool positionCamera = false;
    public bool rotateCamera = false;
    public int currentTransform = 0;
    // Update is called once per frame

    bool preClick = true;


	void Update ()
    {
	if(nextPosition)
        {
            transformCamera();
        }	
	}
}
