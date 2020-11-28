using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Character : MonoBehaviour
{
    private Vector3 _movement;
    private float _racket;
    [SerializeField] protected Rigidbody2D CharRigid;
    [SerializeField] protected float speed;
    [SerializeField] protected Racket charRacket;
    [SerializeField] protected bool isLeft;
    protected virtual void Start()
    {
        //CharRigid = GetComponentInChildren<Rigidbody2D>(); //Getting First child Be careful
    }

    public void ResetPosition()
    {
        CharRigid.velocity = new Vector3(0f, 0f, 0f);
        charRacket.ResetPosRacket();
        CharRigid.position = new Vector3((isLeft ? -1: 1)*7f, 0f, 0f);
    }

    private void Move()
    {
        _movement =new Vector3(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"),0);
        CharRigid.AddForce(_movement * -speed, ForceMode2D.Impulse);
        _racket = Input.GetAxis("Racket");
        if(Math.Abs(_racket) > 0.1)
            charRacket.Swing(_racket/10);
        
    }

    protected virtual void Update()
    {
        Move();
    }
}
