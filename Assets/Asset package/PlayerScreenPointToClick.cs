﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScreenPointToClick : MonoBehaviour {
    //GameObject capsuleCasting_Brush;
    /// <summary>
    /// Score keeping will gather the score for storing variables of the name, the time if on a time run. Points based on difficulty of the facial hairs to cut.
    /// Hairs cut to say how many you did successfully. Unsuccessful_hairsCut to score how many you failed to cut. facesDone to count faces completed or attempted!
    /// facesSkipped to count the faces you did not do.
    /// </summary>
    [System.Serializable]
    public struct scoreKeeping
    {
        [SerializeField] public string player_Name;
        [SerializeField] public int time;
        [SerializeField] public int points;
        [SerializeField] public int scorePool;
        [SerializeField] public int highScore;
        [SerializeField] public int Successful_hairsCut;
        [SerializeField] public int Unsuccessful_hairsCut;
        [SerializeField] public int facesDone;
        [SerializeField] public int facesSkipped;
    }
    public void nextHead(bool wasSkipped)
    {
        if (wasSkipped)
            myScore.facesSkipped++;
        else
            myScore.facesDone++;
        return;
    }
    [SerializeField] public scoreKeeping myScore;
    public Text scoreKeeping_Text;
    /* Keep score of hairs cut and get value from the head
     * 
     * 
     * If i am clicking a mouse, or touching a screen on a mobile device screenPointRaycast to location 
     * If it hits hair knock it off and send a message
     * If it hits the face stop the ray, hit it with the force of speed and direction and bopple the head in a direction
     * 
     *
     * Get swipe speed from basics of <speed = distance / timedifference;>
     *
     */
    public Transform Locators;
    public Camera cam;

    // Use this for initialization
    void Start ()
    {
        playerProfile.main.loadProfiles();
        cam = GetComponent<Camera>();

        if (isMobile)
            ray_Offset = MobileTuning;
        else
            ray_Offset = DesktopTuning;
        //Setup a Ray vector location to generate ray from based on origin and not origin locations and radius locations.
        ////ray_FireLocations = new Vector3[ray_Tuning];
        ////Vector3 radiusOffset;
        ////for (int i = 0; i < ray_Tuning; i++)
        ////{
        ////    if(i != 0)
        ////    {
        ////        ray_FireLocations[i] = new Vector3(0, 0, 0) * ray_Offset;
        ////    }
        ////}
    }

    // Update is called once per frame
    //int ray_Tuning = 9;
    public float MobileTuning = 0.1f;
    public float DesktopTuning = 0.05f;
    public bool isMobile;


    float ray_Offset = 0.05f;


    [Header("Physics Variables (Impact location of brush)")]
    public float constantForce = 0.5f;
    public float maximumForce = 15f;
    [SerializeField] private float playerSwipeSpeed;
    public float speedDensity_Mouse = 100f;


    Vector3 mousePos;
    Vector3 mouseEnd;


    public void canFire(bool _canFire)
    {
        if (gameManagerScript.running == true)
            canDestroyBeard = _canFire;
        else
            canDestroyBeard = false;
        return;
    }

    public Vector3 dir;
    public Vector3 directionFromImpact;
    public Vector3 directionalMultiplier;
    //Vector3[] ray_FireLocations;
    void Update () {

            mousePos = Input.mousePosition;

        if (Input.GetButton("Fire1") && canDestroyBeard)
        {

        dir = mousePos - mouseEnd;
 
            float distance_Mouse = Vector3.Distance(mousePos, mouseEnd);
            playerSwipeSpeed = (distance_Mouse / Time.deltaTime) / speedDensity_Mouse;
            mouseEnd = mousePos;
            Vector3 hitForce = playerSwipeSpeed * (dir.x * Camera.main.transform.right + dir.y * Camera.main.transform.up); //Suggested by Dr Mike Cooper 4/1/2017
            //Vector3 hitForce = dir * playerSwipeSpeed;

            //Vector3 directionToCorrect = directionCorrection();
        //directionalMultiplier = directionToCorrect;
        //hitForce = correctThisDirection(directionToCorrect, hitForce);
        directionFromImpact = hitForce;
            Debug.LogError("Vector direction based on rotation is incorrect. Line 107 and 115.");
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition + new Vector3(0, 0, 0));
            Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);
            //for (int i = 0; i < ray_Tuning; i++)
            //{
            if (Physics.SphereCast(ray, ray_Offset, out hit))
                {
                    Debug.DrawRay(ray.origin, ray.direction * 10, Color.cyan, 15);
                    Debug.Log("Before destroying thing");
                    if (hit.collider.gameObject.tag == "facialHair"/* && canDestroyBeard*/)
                    {
                        Debug.Log("Destroy thing");
                        hit.collider.gameObject.GetComponent<hairScore>().IAmHit(this);
                        //GameObject destroy = hit.collider.gameObject;
                        //Destroy(destroy);
                    }
                if (hit.collider.gameObject.tag == "face")
                {
                    Rigidbody rb_2 = hit.collider.GetComponent<BobbleHeadStatistics>().getRigidBody();
                    Debug.Log("Is rb_2 = to null? - " + rb_2 != null);
                    //Rigidbody rb_2 = FindRigidBodyOnParents(hit.collider.gameObject);
                    if (rb_2 != null)
                    {
                        //Add force at hitPoint
                        rb_2.AddForceAtPosition(hitForce, hit.point);
                        //rb_2.AddRelativeTorque(hitForce);
                    }
                    else
                    {
                        rb_2 = hit.collider.GetComponent<BobbleHeadStatistics>().getRigidBody();
                        if(rb_2 != null)
                        {
                            rb_2.AddForceAtPosition(hitForce, hit.point);
                            //rb_2.AddRelativeTorque(hitForce);
                        }
                    }
                }

                //}
            }
                //Instantiate(particle, transform.position, transform.rotation);
        }

        if (scoreKeeping_Text != null)
        {
            scoreKeeping_Text.text = "";
            scoreKeeping_Text.text += "Point: " + myScore.points + "\n" + "Shaved: " + (myScore.Successful_hairsCut + myScore.Unsuccessful_hairsCut) + "\n" + "Faces Skipped: " + myScore.facesSkipped + "\n" + "Faces Completed: " + myScore.facesDone + "\n";
        }
        //Time for this run
        //How many faces I completed
        //How many faces I Skipped!

    }

    private bool canDestroyBeard = false;
    public bool DestroyBeard
    {
        get
        {
            return canDestroyBeard;
        }
        set
        {
            canDestroyBeard = value;
        }
    }

    Rigidbody FindRigidBodyOnParents(GameObject go)
    {
        Transform t = go.transform;
        while (t != null)
        {
            Rigidbody rb = t.GetComponent<Rigidbody>();
            if (rb != null)
                return rb;
            t = t.parent;
        }
        return null;
    }
}
