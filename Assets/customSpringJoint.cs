using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class customSpringJoint : MonoBehaviour {


    public Vector3 originLocalRotation;
    public Vector3 threshold;
    Vector3 old_Threshold;

    Vector3 position;
    public struct bounds
    {
       [SerializeField] public Vector3 bounds_A;
       [SerializeField] public Vector3 bounds_B;
    }
    public bounds bound_Threshold;

    public float dampning;
    Rigidbody rb;
    // Use this for initialization
	void Start () {
        originLocalRotation = transform.eulerAngles;
        rb = transform.GetComponent<Rigidbody>();
        old_Threshold = threshold;
        position = transform.position;
	}
	
    void recalculateThreshold()
    {
        //If number is greater than originLocalRotation
        bound_Threshold.bounds_A = originLocalRotation + threshold; 
        
        //If number is less than originLocalRotation
        bound_Threshold.bounds_B = originLocalRotation - threshold;
        old_Threshold = threshold;
        return;
    }

	// Update is called once per frame
	void Update ()
    {
        if(old_Threshold != threshold)
        {
            recalculateThreshold();
        }

        //transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, originLocalRotation, 0.001f);
        //Vector3 direction =  transform.eulerAngles - originLocalRotation;
        //rb.AddRelativeTorque(-direction * 0.1f);
        ///If rotation goes beyond a threshold range... The Ridgid body will have opposed forces to return it to stop it going beyond a certain position.
        /// Get force
        /// Apply opposng force * 1.01
        //https://answers.unity.com/questions/407085/add-torque-at-position.html
        transform.position = position; //Game glitch RB moves the head position.
    }
}
