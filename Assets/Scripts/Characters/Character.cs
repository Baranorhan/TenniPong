using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Character : MonoBehaviour
{
    protected Rigidbody2D CharRigid;
    public float speed = 10.0f;
    [SerializeField] protected Racket charRacket;
    public bool isLeft;
    private void Start()
    {
        CharRigid = GetComponentInChildren<Rigidbody2D>(); //Getting First child Be careful
    }

    public void ResetPosition()
    {
        CharRigid.velocity = new Vector3(0f, 0f, 0f);
        charRacket.ResetPosRacket();
        CharRigid.position = new Vector3((isLeft ? -1: 1)*7f, 0f, 0f);
    }
    
    
}
