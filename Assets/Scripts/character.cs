using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character : MonoBehaviour
{
    private Rigidbody2D CharRigid;
    public float speed = 10.0f;

    private void Start()
    {
        CharRigid = gameObject.GetComponent<Rigidbody2D>();
        
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            CharRigid.AddForce(transform.up * speed,  ForceMode2D.Impulse);
        }
        if (Input.GetKey(KeyCode.A))
        {
            CharRigid.AddForce(transform.right * -speed , ForceMode2D.Impulse);
        }
        if (Input.GetKey(KeyCode.D))
        {
            CharRigid.AddForce(transform.right * speed , ForceMode2D.Impulse);
        }
        if (Input.GetKey(KeyCode.S))
        {
            CharRigid.AddForce(transform.up * -speed , ForceMode2D.Impulse);
        }
    }
}
