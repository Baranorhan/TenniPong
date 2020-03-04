using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class racket : MonoBehaviour
{
    private Rigidbody2D racketRigid;
    public float speed = 10.0f;
    public bool isAI;
    private float SwingRot = 0;
    private void Start()
    {
        racketRigid = gameObject.GetComponent<Rigidbody2D>();
    }

  
    public void Swing(int rot)
    {
        racketRigid.AddForce(transform.right * rot * speed, ForceMode2D.Impulse);
    }
}
