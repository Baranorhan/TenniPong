using System;
using Photon.Pun;
using UnityEngine;

public class NetworkHuman : MonoBehaviourPunCallbacks 
{
    protected Rigidbody2D CharRigid;
    private Vector3 _movement;
    private float _racket;
    [SerializeField] protected float speed = 10.0f;
    [SerializeField] protected Racket charRacket;
    [SerializeField] protected bool isLeft;

    private void Update()
    {
        if (photonView.IsMine == true && PhotonNetwork.IsConnected == true)
            Move();
    }
    private void Awake()
    {
        CharRigid = GetComponentInChildren<Rigidbody2D>(); //Getting First child Be careful
    }

    private void Move()
    {
        _movement =new Vector3(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"),0);
        CharRigid.AddForce(_movement * -speed, ForceMode2D.Impulse);
        _racket = Input.GetAxis("Racket");
        if(Math.Abs(_racket) > 0.1)
            charRacket.Swing(_racket);
        
    }

    public void ResetPosition()
    {
        CharRigid.velocity = new Vector3(0f, 0f, 0f);
        charRacket.ResetPosRacket();
        CharRigid.position = new Vector3((isLeft ? -1: 1)*7f, 0f, 0f);
    }
}