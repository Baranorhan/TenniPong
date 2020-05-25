using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalGate : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.layer == 9)
            transform.parent.parent.GetComponent<GameManagerML>().Goal(this);
    }

}
