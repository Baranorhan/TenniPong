using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Racket : MonoBehaviour
{
    private Rigidbody2D racketRigid;
    public float speed = 10.0f;
    private Vector3 StartVel, StartPos;
    private float Startrot;

    private void Start()
    {
        racketRigid = gameObject.GetComponent<Rigidbody2D>();
        StartVel = racketRigid.velocity;
        StartPos = racketRigid.position;
        Startrot= racketRigid.rotation;
    }

    public void Swing(int rot)
    {
        racketRigid.AddForce(transform.right * rot * speed, ForceMode2D.Impulse);
    }

    public void ResetPosRacket()
    {
        racketRigid.velocity = StartVel;
        racketRigid.position = StartPos;
        racketRigid.rotation = Startrot;

    }
}
