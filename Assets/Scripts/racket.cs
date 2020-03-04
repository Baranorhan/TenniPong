using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class racket : MonoBehaviour
{
    private Rigidbody2D racketRigid;
    public float speed = 10.0f;

    private void Start()
    {
        racketRigid = gameObject.GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            racketRigid.AddForce(transform.right * speed, ForceMode2D.Impulse);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            racketRigid.AddForce(transform.right * -speed, ForceMode2D.Impulse);
        }
    }
}
