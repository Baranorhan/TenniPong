using System;
using UnityEngine;

public class Human : Character
{
    private Vector3 _movement;
    private float _racket;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        _movement =new Vector3(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"),0);
        CharRigid.AddForce(_movement * -speed, ForceMode2D.Impulse);
        _racket = Input.GetAxis("Racket");
        if(Math.Abs(_racket) > 0.1)
            charRacket.Swing(_racket);
        
    }
}