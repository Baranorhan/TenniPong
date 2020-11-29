using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Character : MonoBehaviour
{
    private Vector3 _movement;
    protected float _racket;
    protected Rigidbody2D _charRigid;
    [SerializeField] protected float speed;
    [SerializeField] protected Racket charRacket;
    [SerializeField] protected bool isLeft;
    protected virtual void Start()
    {
        _charRigid = GetComponent<Rigidbody2D>();
    }

    public void ResetPosition()
    {
        Debug.Log(_charRigid.position);
        _charRigid.velocity = new Vector3(0f, 0f, 0f);
        charRacket.ResetPosRacket();
        _charRigid.position = new Vector3((isLeft ? -1: 1)*7f, 0f, 0f);
    }

    private void Move()
    {
        _movement =new Vector3(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"),0);
        _charRigid.AddForce(_movement * -speed, ForceMode2D.Impulse);
        _racket = Input.GetAxis("Racket");
        if(Math.Abs(_racket) > 0.1)
            charRacket.Swing(_racket/10);
    }

    protected virtual void FixedUpdate()
    {
        Move();
    }
}
