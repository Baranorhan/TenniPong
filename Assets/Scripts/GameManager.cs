using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI _score;
    protected int _scoreLeft = 0, _scoreRight = 0 ;
    [SerializeField] protected Character leftChar, rightChar;
    [SerializeField] protected Rigidbody2D ball;
    public void Goal(GoalGate wall)
    {
        Debug.Log(_scoreRight);
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
        rightChar.ResetPosition();    //TODO singleton this add clones at network manager.
        
    }

    void Start()
    {
        ResetBall();
    }

    protected void  ResetBall()
    {
        Debug.Log(ball.position);

        ball.rotation = 0;
        ball.position = new Vector3(-0.2f, 0, 0);
        ball.velocity = new Vector3(0, 0, 0);
        ball.angularVelocity = 900;

    }

}