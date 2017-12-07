using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Manager : MonoBehaviour {


    [SerializeField] private progressionReportSystem[] PRS_;
	// Use this for initialization
	void Start ()
    {
        PRS_ = FindObjectsOfType<progressionReportSystem>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
