using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class progressionReportSystem : MonoBehaviour {

    //public progressionReportSystem[] PRS_;

    /// Weight system using Struct or class could be useful like in Kataklizma.
    /// Weight per face depending on who was most commonly known and seen in the AIE community.
    /// Rarity is based on how often we saw them. But also how well we remember!
    /// Common people are Adam at 60%, Mark 10%, Matt 15%, Chris 15% etc.
    [Tooltip("It has to instantiate at THIS Specific location. So be happy with where it resides!")]
    public GameObject[] MultipleHeadsToShave;
    //GameObject insantiatedRefrence;

    void Awake()
    {
        //PRS_ this;
    }
	// Use this for initialization
	void Start () {
        //PRS_ = this;
		        Debug.Log("Incomplete Script functionality!");
        ///Requires:
        /// liveGameSetup script link from parent!
        /// function call to change transform position!
        /// OnKill the gameObject created is destroyed!!!
        /// Requires way to spawn in Bobble heads!
	}

    //bool OnDestroy_DontEmitParticles = false;
    [SerializeField]
    private GameObject instantiatedReference;
    public void OnKill()
    {
        if (instantiatedReference != null)
        {
            //OnDestroy_DontEmitParticles = true;
            instantiatedReference.GetComponentInChildren<BobbleHeadStatistics>().processParticlesDestructionProtocall();
            Destroy(instantiatedReference);
        }
        instantiatedReference = null;
        return;
    }

    public Transform OnRespawn()
    {
        if (instantiatedReference == null)
        {
            int rng = Random.Range(0, MultipleHeadsToShave.Length);
            instantiatedReference = Instantiate(MultipleHeadsToShave[rng], transform);
            return this.transform;
        }
        else return null;
    }

	// Update is called once per frame
	void Update () {

		
	}
}
