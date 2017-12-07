using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobbleHeadStatistics : MonoBehaviour {

    public GameObject particleDeathSmokeBurst;
    float delay;
    public float offset_Self_Destruction = 1.5f;

    void Start()
    {
        //if (particleDeathSmokeBurst != null)
        //    if (particleDeathSmokeBurst.GetComponent("ParticleSystem") != null)
        //    {
        //        ParticleSystem prtSyst = particleDeathSmokeBurst.GetComponent<ParticleSystem>();
        //        delay = prtSyst.startDelay + prtSyst.startLifetime + prtSyst.duration;
        //        Instantiate(prtSyst, transform);
        //        Destroy(transform, delay);
        //    }

    }
    bool destroying = false;
    void selfDestruct()
    {
        if(particleDeathSmokeBurst != null)
        {
            GameObject toDestroy = Instantiate(particleDeathSmokeBurst);
        }
        else
        {
            if (particleDeathSmokeBurst != null)
                if (particleDeathSmokeBurst.GetComponent("ParticleSystem") != null)
                {
                    ParticleSystem prtSyst = particleDeathSmokeBurst.GetComponent<ParticleSystem>();
                    delay = prtSyst.startDelay + prtSyst.startLifetime + prtSyst.duration;
                    Instantiate(prtSyst, transform);
                    Destroy(transform.gameObject, delay);
                }
            //Destroy(transform, offset_Self_Destruction);
        }
    }

    void Update()
    {
        if(transform.GetChild(0) != null && !destroying)
        {
            Transform children = GetComponentInChildren<Transform>();
            foreach(Transform child in children)
            {
                if(child.tag == "facialHair")
                {
                    return;
                }
         
                       
            }
            destroying = true;
            selfDestruct(); //Destroy self and request respawn!

        }
    }
/*
 * Keep values for failure to shave
 * Keep value of points for success to shave
 * Keep count of hair count
 * 
 */
}
