using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class liveGameSetup : MonoBehaviour {

    public Transform mainCamera = null;

    [System.Serializable] public struct levelProgression
    {
        public Transform moveTo;
        public progressionReportSystem toProcess;
    }
    public levelProgression[] movePoints;
    int movePoints_Location = 0;
    PlayerScreenPointToClick player;
    [SerializeField] private progressionReportSystem[] toBeShavedFaceRig = null; 
	// Use this for initialization
	void Start ()
    {
        FindObjectOfType<gameManagerScript>().returnLiveGameSetup(this);
        Transform[] children = GetComponentsInChildren<Transform>();
        mainCamera = Camera.main.gameObject.transform;
        player = mainCamera.GetComponent<PlayerScreenPointToClick>();

        transformFilter();
        a = returnNewScriptSpawner(0);

        mainTransform(movePoints[movePoints_Location].moveTo, false);
    }



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
        return;
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
    /// Process 2.Start
    /// </summary>
    //public void nextTarget()
    //{
    //    Debug.Log("Next target!");
    //    player.canFire(false);
    //    nextPosition = true;

    //    //BUG: If the number is 1 it will glitch. If 0 it will only return to the original A Coordinates.
    //            b = returnNewScriptSpawner(1);

    //    return;
    //}

    /// <summary>
    /// Returns the Transform in the order of selection to do stuff with.
    /// </summary>
    /// <returns></returns>
    Transform returnNewScriptSpawner(int newCurrentTransform)
    {

        //currentTransform
        int i = 0;
        newCurrentTransform += currentTransform;
        ///a = newCurrentTransform - I
        /// 
        // -37 + i = 0;
        //


        while(i < movePoints.Length)
        {
            if(newCurrentTransform + i > movePoints.Length - 1)
            {
                newCurrentTransform = 0 - i;
                //newCurrentTransform = newCurrentTransform;
            }
            Debug.Log("Transform compaired Current:Length = " + (newCurrentTransform + i) + " : " + movePoints.Length);
            if (movePoints[newCurrentTransform + i].toProcess != null)
            {
                b_Position = newCurrentTransform + i;
                return movePoints[newCurrentTransform + i].toProcess.OnRespawn();
            }
            //newCurrentTransform++;
            i++;
        }
        return null;
    }



    //bool go = false;
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

                preClick = false;
                player.canFire(false);
                if(rotateCamera || positionCamera)
                if (b == null)
                {
                    nextPosition = true;

                    //BUG: If the number is 1 it will glitch. If 0 it will only return to the original A Coordinates.
                    Debug.LogWarning("BUG Stagers due to following line of code.");
                    b = returnNewScriptSpawner(1);

                    //BUG: If the number is 1 it will glitch. If 0 it will only return to the original A Coordinates.
                }
                MoveAtTime = Time.time + timeSpeedDelayVariblesBetweenTransitions;
                //nextTarget();

            }
            else if (positionCamera) //Time speed delay variables
            {

                mainCamera.position = Vector3.Lerp(mainCamera.position, movePoints[currentTransform].moveTo.position, travelSpeedOverTime);
                float distance = Vector3.Distance(mainCamera.position, movePoints[currentTransform].moveTo.position);
                if (distance < distanceSensitivity)
                {
                    rotateCamera = true;
                    positionCamera = false;
                    MoveAtTime = Time.time + timeSpeedDelayVariblesBetweenTransitions;
                }
            }
            else if (rotateCamera) //Time speed delay variables
            {
                mainCamera.eulerAngles = LerpThisAngle(mainCamera.eulerAngles, movePoints[currentTransform].moveTo.eulerAngles, travelSpeedOverTime); //Suggested by Dr Mike Cooper 4/1/2018 around 5PM

                float distance = Vector3.Distance(mainCamera.eulerAngles, movePoints[currentTransform].moveTo.eulerAngles);
                if (distance < distanceSensitivity)
                {
                    //positionCamera = false;
                    rotateCamera = false;
                    MoveAtTime = Time.time + timeSpeedDelayVariblesBetweenTransitions;
                }
            }
        }
        else if (!positionCamera && !rotateCamera && nextPosition) //Don,t move, don't rotate, go to next position!
        {
            //if(movePoints[currentTransform].toProcess != null)
            //Test for stop on thing!
            Debug.Log("Requires Filter and logic loops.");
            if (currentTransform == b_Position)
                if (movePoints[currentTransform].toProcess != null)
                {

                    nextPosition = false;
                    if (a && b != null)
                    {
                        Debug.LogError("Break point! - Kill's the A Position NPC...");
                        a.gameObject.GetComponent<progressionReportSystem>().OnKill();
                        a = b;
                        b = null;
                        player.canFire(true);
                        preClick = true; //Solve the glitching? YES
                    }
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

            //preClick = true; //Makes spawners work? YES
            //else
            //{
            //    currentTransform = 0;
            //}
            //if()
        }
    }

    Vector3 LerpThisAngle(Vector3 a, Vector3 b, float t)
    {
        return new Vector3(Mathf.LerpAngle(a.x, b.x, t), Mathf.LerpAngle(a.y, b.y, t), Mathf.LerpAngle(a.z, b.z, t));
    }

    public void skipHead()
    {
        if (!nextPosition)
        {
            nextPosition = true;
            mainCamera.GetComponent<PlayerScreenPointToClick>().nextHead(true);
        }
    }

    public void headCompleted()
    {
        nextPosition = true;
        mainCamera.GetComponent<PlayerScreenPointToClick>().nextHead(false);
    }

    [Header("Camera transform tuning tools")]
    public float travelSpeedOverTime = 0.2f;
    public float distanceSensitivity = 0.3f;
    public float timeSpeedDelayVariblesBetweenTransitions = 1.6f;
    [SerializeField] private float MoveAtTime = 0;
    [Header("To be Private variables")]
    bool nextPosition = true;
    bool positionCamera = false;
    bool rotateCamera = false;
    int currentTransform = 0;
    // Update is called once per frame

    int highestNumericValue = 0;

    Transform a;
    Transform b;
    int b_Position;

    bool preClick = true;

    public void HairSet_Complete()
    {
        player.myScore.facesDone++;
        nextPosition = true;
        return;
    }


	void Update ()
    {
	if(nextPosition)
        {
            transformCamera();
        }	
	}
}
