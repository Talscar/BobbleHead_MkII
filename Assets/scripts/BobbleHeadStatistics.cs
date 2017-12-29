using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobbleHeadStatistics : MonoBehaviour {


    public Transform alt_pivotPointHead;
    Rigidbody pivotPointBody;

    public GameObject particleDeathSmokeBurst;
    float delay;
    public float offset_Self_Destruction = 1.5f;

    public Rigidbody getRigidBody()
    {
        return pivotPointBody;
    }

    void Start()
    {
        if(alt_pivotPointHead != null)
        {
            if(alt_pivotPointHead.GetComponent("Rigidbody") != null)
            {
                pivotPointBody = alt_pivotPointHead.GetComponent<Rigidbody>();
                transform.parent = pivotPointBody.transform;
            }
            else
            {
                Debug.LogError("Failed to locate a Rigidbody on - " + alt_pivotPointHead);
                //Application.Quit();
            }
        }
        else
        {
            pivotPointBody = transform.GetComponent<Rigidbody>();
        }
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
        Debug.LogWarning("If destroyed before declaring completion or updating visuals. Or before secondary transition is complete, the game will break!");
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

    public void processParticlesDestructionProtocall()
    {
        Transform[] children = transform.GetComponentsInChildren<Transform>();
        foreach(Transform child in children)
        {
            if(child.GetComponent("hairScore") != null)
            {
                child.GetComponent<hairScore>().dontSpawnParticlesOnDeath();
            }
        }
        return;
    }
    /*
     * Keep values for failure to shave
     * Keep value of points for success to shave
     * Keep count of hair count
     * 
     */
    public void reset()
    {

    }


    int hairSets = 0;
    public void HairSet_Update()
    {
        hairSets--;
        Debug.LogWarning("Incomplete Functionality!");
        if(hairSets <= 0)
        {
            FindObjectOfType<liveGameSetup>().HairSet_Complete();
        }

        //Do a check if 0 and update transform stuff so it goes to the next bobble head!
    }

    public void HairSet_Start()
    {
        hairSets++;
        return;
    }
}
