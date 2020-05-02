using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : Character
{
   
    // Update is called once per frame
    void Update()
    {
       
        if(photonView.IsMine)
        {
            if (Input.GetKey(KeyCode.W))
            {
                CharRigid.AddForce(transform.up * speed, ForceMode2D.Impulse);
            }
            if (Input.GetKey(KeyCode.A))
            {
                CharRigid.AddForce(transform.right * -speed, ForceMode2D.Impulse);
            }
            if (Input.GetKey(KeyCode.D))
            {
                CharRigid.AddForce(transform.right * speed, ForceMode2D.Impulse);
            }
            if (Input.GetKey(KeyCode.S))
            {
                CharRigid.AddForce(transform.up * -speed, ForceMode2D.Impulse);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                CharRacket.Swing(+1);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                CharRacket.Swing(-1);
            }
        }
    }
}
