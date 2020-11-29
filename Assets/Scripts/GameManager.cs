using System.Collections;
using System.Collections.Generic;
using System.Security.AccessControl;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class GameManager : MonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI _score;
    protected int _scoreLeft = 0, _scoreRight = 0 ;
    private Character leftChar, rightChar;
    private Rigidbody2D ball;
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

        ResetBall();
        leftChar.ResetPosition();
        rightChar.ResetPosition();    
        
    }

    void Start()
    {
        ResetBall();
    }

    protected void  ResetBall()
    {
        ball.rotation = 0;
        ball.position = new Vector3(-0.0f, 0, 0);
        ball.velocity = new Vector3(0, 0, 0);
        ball.angularVelocity = 900;

    }
    
    public void SetPlayersandBall()
    {

        leftChar = GameObject.Find("Left(Clone)").GetComponent<Character>();
        rightChar = GameObject.Find("Right(Clone)").GetComponent<Character>();
        ball = GameObject.Find("Ball(Clone)").GetComponent<Rigidbody2D>();
        
    }

}