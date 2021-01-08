using System;
using UnityEngine;

public class Human : Character
{

    protected override void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        _movement =new Vector3(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"),0);
        _charRigid.AddForce(_movement * -speed, ForceMode2D.Impulse);
        _racket = Input.GetAxis("Racket");
        if(Math.Abs(_racket) > 0.1)
            charRacket.Swing(_racket);
        
    }
}