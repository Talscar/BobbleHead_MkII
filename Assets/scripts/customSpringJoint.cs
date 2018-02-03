using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class customSpringJoint : MonoBehaviour {
    [Tooltip("Threshold in which the opposing force will react and present more force in the opposing direction.")]
    public Vector3 threshold;
    [Tooltip("Increases the weight to which the spring will react in the opposing direction.")]
    public float dampning = 600f;

    [Tooltip("Weight and hardness of the spring joint.")]
    public float springWeight = 0.9f;

    [SerializeField] private Vector3 originLocalRotation;
    Vector3 old_Threshold;
    Vector3 position;

    Rigidbody rb;

    // Use this for initialization
    void Start () {
        dampning = 15000;
        transform.eulerAngles = Vector3.zero;
        originLocalRotation = transform.eulerAngles;
        rb = transform.GetComponent<Rigidbody>();
        old_Threshold = threshold;
        position = transform.position;
        Debug.LogWarning("calculateRotation() could be more efficient... Maybe!");

	}
	
    void recalculateThreshold()
    {
        old_Threshold = threshold;
        return;
    }
    Vector3 new_Force_Direction;

    void calculateRotation()
    {

        float forceMultiplier;
        Vector3 rotationWithThreshold = originLocalRotation + threshold;
        if (transform.eulerAngles.x < 360)
        {

            if (transform.eulerAngles.x < 180)
            {
                new_Force_Direction.x = -transform.eulerAngles.x * (1 / rotationWithThreshold.x/*(originLocalRotation.x + threshold.x)*/);// * transform.eulerAngles.x; 
            }
            else //It's 360
            {
                new_Force_Direction.x = (360 - transform.eulerAngles.x) * (1 / rotationWithThreshold.x/*(originLocalRotation.x + threshold.x)*/);// * transform.eulerAngles.x; 
            }
        }
        if (transform.eulerAngles.y < 360)
        {
            if (transform.eulerAngles.y < 180)
            {
            new_Force_Direction.y = -transform.eulerAngles.y * (1 / rotationWithThreshold.y/*(originLocalRotation.y + threshold.y)*/);// * transform.eulerAngles.y; 
            }
            else //It's 360
            {
                new_Force_Direction.y = (360 - transform.eulerAngles.y) * (1 / rotationWithThreshold.y/*(originLocalRotation.y + threshold.y)*/);// * transform.eulerAngles.y; 
            }
        }

        if (transform.eulerAngles.z < 360)
        {
            if (transform.eulerAngles.z < 180)
            {
                new_Force_Direction.z = -transform.eulerAngles.z * (1 / rotationWithThreshold.z/*(originLocalRotation.z + threshold.z)*/);// * transform.eulerAngles.z;
            }
            else //It's 360
            {
                new_Force_Direction.z = (360 - transform.eulerAngles.z) * (1 / rotationWithThreshold.z/*(originLocalRotation.z + threshold.z)*/);// * transform.eulerAngles.z;
            }
        }

        return;
    }
    //void

    [SerializeField]
    private Vector3 newTorque;

    // Update is called once per frame
    void Update ()
    {
        transform.position = position; 
        if(old_Threshold != threshold)
        {
            recalculateThreshold();
        }
        calculateRotation();

        newTorque = (new_Force_Direction * dampning) * Time.deltaTime;
        rb.AddTorque(((new_Force_Direction * dampning) * Time.deltaTime));
        rb.angularVelocity = (rb.angularVelocity * springWeight);

    }
}
