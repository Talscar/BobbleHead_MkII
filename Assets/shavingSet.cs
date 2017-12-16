using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shavingSet : MonoBehaviour {

   public int childrenToShave = 0;

    public int shavingZeroByPercent = 0; //This be the point in which it will say "Yes i am complete" this is for player difficulty and leniancy. Nothing needs to be perfect in a game! So long as its fun and the player is trying and feeling successful.
	//Start function calculate the childrenToShave find a difficulty value based on skill to determin what you can and can't shave total.
    
    
    // Use this for initialization
	void Start ()
    {
        shavingZeroByPercent = (int)((childrenToShave / 0.9) - childrenToShave);   		
	}

    public void hairShaving_Score_Update()
    {
        childrenToShave--;
        if (childrenToShave < shavingZeroByPercent || childrenToShave <= 0)
        {
            BobbleHeadStatistics talk = transform.GetComponentInParent<BobbleHeadStatistics>();
            talk.HairSet_Update();
            //Do stuff! Progress to next head!
            //Tell BobbleHeadStatistics i am done!
        }
        else
            return;
    }

    public void hairShave_Start()
    {
        childrenToShave++;
        return;
    }
	
    
	// Update is called once per frame
	void Update () {
		
	}
}
