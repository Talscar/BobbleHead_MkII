﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hairScore : MonoBehaviour {


    public int hairCutValue;
    public bool dontCutThis = false;
    //public bool canCut;
    public GameObject ParticleEmmiter;
    [SerializeField] private float ParticleEmmiter_LifeTime;

    shavingSet toShaveSet;

    void Awake()
    {
        ParticleSystem particleSystem_New = ParticleEmmiter.GetComponent<ParticleSystem>();
        ParticleEmmiter_LifeTime = (particleSystem_New.duration + particleSystem_New.startLifetime); //May require a percent variable.

        toShaveSet = transform.GetComponentInParent<shavingSet>();
        if(!dontCutThis)
        {
            if (toShaveSet != null)
            {
                toShaveSet.hairShave_Start();
            }
            else
                Debug.LogError("NO PARENT FOUND!!!");
        }
    }

    public void dontSpawnParticlesOnDeath()
    {
        ParticleEmmiter = null;
        return;
    }
    /// <summary>
    /// Tells the hair it was hit and requires to process it's own death.
    /// </summary>
    public void IAmHit(PlayerScreenPointToClick player)
    {
        if (dontCutThis)
        {
            player.myScore.points += hairCutValue;
            player.myScore.Unsuccessful_hairsCut++;
        }
        else
        {
            player.myScore.points += hairCutValue;
            player.myScore.Successful_hairsCut++;
        }
        Destroy(gameObject);
    }

    void OnDestroy()
    {
        if (ParticleEmmiter != null)
        {
            if(!dontCutThis)
            {
                toShaveSet.hairShaving_Score_Update();
            }
            //Transform.localToWorldMatrix
            // Vector3 newPoint = transform.Transform.localPosition(this.transform.position);//(Transform)Transform.localToWorldMatrix(transform); 
            //transform.TransformPoint(0, 0, 0);//this.transform.Transform.TransformPoint(this.transform.position);        Vector3 thePosition = transform.TransformPoint(2, 0, 0);
            //Vector3 newCoordinate = new Vector3();
            //Vector3 newCoordinates = (this.transform.position) + centerPoint;
            //Debug.LogWarning(newCoordinates + " - to this set: " + centerPoint + " : " + transform.position);
            //Debug.DrawRay(this.transform.position, new Vector3(10, 10, 10), Color.yellow, 99f);
            GameObject newParticle = Instantiate(ParticleEmmiter, transform.position/*(this.transform.position) + centerPoint*//*newCoordinates*//*returnMyCoordinatesInWorldSpaceToTransform(transform)*/, gameObject.transform.localRotation);
            newParticle.transform.parent = this.transform;
            Destroy(newParticle, ParticleEmmiter_LifeTime);
        }
    }
}
