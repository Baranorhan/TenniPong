using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Character : MonoBehaviourPunCallbacks
{
    protected Rigidbody2D CharRigid;
    public float speed = 10.0f;
    public Racket CharRacket;
    private Transform StatPos;
    public int isLeft;
    private void Start()
    {
        CharRigid = GetComponentInChildren<Rigidbody2D>(); //GEtting First child Be careful
   
    }


    public void ResetPosition()
    {
        CharRigid.velocity = new Vector3(0f, 0f, 0f);
        CharRacket.ResetPosRacket();
        CharRigid.position = new Vector3(-isLeft*7f, 0f, 0f);

    }
}
