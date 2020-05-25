﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _score;
    private int _scoreLeft = 0, _scoreRight = 0 ;
    [SerializeField] private Character leftChar, rightChar;
    [SerializeField] private Rigidbody2D ball;
    public void Goal(GoalGate wall)
    {
        if (wall.name.Equals("LeftCollider"))
        {
            _scoreLeft += 1;
        }
        else
        {
            _scoreRight += 1;
        }

        _score.text = _scoreLeft + "         " + _scoreRight;
        
        leftChar.ResetPosition();
        rightChar.ResetPosition();
        ResetBall();
    }

    // Start is called before the first frame update
    void Start()
    {
        ResetBall();
    }

    private void  ResetBall()
    {
        ball.rotation = 0;
        ball.position = new Vector3(-0.2f, 0, 0);
        ball.velocity = new Vector3(0, 0, 0);
        ball.angularVelocity = 900;

    }

}