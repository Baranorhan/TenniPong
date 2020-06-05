using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalGate : MonoBehaviour
{
    private GameManager _gameManager;
    private GameManagerML _gameManagerMl;
    private bool _mlMode;
    private void Start()
    {
        if (transform.parent.parent.GetComponent<GameManagerML>() != null)
        {
            _gameManagerMl = transform.parent.parent.GetComponent<GameManagerML>();
            _mlMode = true;
            
        }  
        else if (transform.parent.parent.GetComponent<GameManager>() != null)
        {
            _gameManager = transform.parent.parent.GetComponent<GameManager>();
            _mlMode = false;
        }
        else throw new System.ArgumentException("No Game Manager Found");

    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.layer != 9) return;
        if (_mlMode)
        {
            _gameManagerMl.Goal(this);
        }
        else _gameManager.Goal(this);
    }

}
