using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceBobble_Relocator : MonoBehaviour {
    public Transform faceToRelocate;
    Vector3 ownRefrence;

    [System.Serializable]public struct sensitivityVariables
    {
        [Header("Rotation sensitivity and store")]
        public float maxRange;
        public float maxRotation;
        public Vector3 eular_Rotation_Origin;
        [Header("Sensitivity Options")]
        public float weighing_Force;
        public float bobbleReturn_Force;
        public float constant_Force;
        
    }
    public sensitivityVariables Sensitivity_Options;
	// Use this for initialization
	void Start () {
        if(faceToRelocate == null)
        {
            //vertices = mesh.vertices;
            ////vertOriginalCoordinates = vertices;
            //vertOriginalCoordinates = new Vector3[vertices.Length];
            //for (int i = 0; i < vertices.Length;)
            //{
            //    vertOriginalCoordinates[i] = new Vector3(vertices[i].x, vertices[i].y, vertices[i].z);

            //    i++;
            //}
            //ownRefrence ;
            ownRefrence = new Vector3(faceToRelocate.transform.position.x, faceToRelocate.transform.position.y, faceToRelocate.transform.position.z);
            //Transform[] children = transform.GetChild;
            //foreach(Transform child in transform.children)
            Debug.LogError("If the Face transform is not present, the game can not return face to origin location!");
        }
		
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 direction_pos = transform.position - faceToRelocate.transform.position;
        Vector3 direction_rot = transform.rotation.eulerAngles - faceToRelocate.transform.rotation.eulerAngles;

        //targetDirection = target.position - transform.position; // Save direction
        //distance = targetDirection.magnitude; // Find distance between this object and target object
        //targetDirection = targetDirection.normalized; // Normalize target direction vector

        //if (distance < radius)
        //{
        //    rb.AddForce(targetDirection * forceAmount * Time.deltaTime);
        //}
    }
}
