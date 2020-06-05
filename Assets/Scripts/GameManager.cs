using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _score;
    private int _scoreLeft = 0, _scoreRight = 0 ;
     private Character leftChar, rightChar;
     private Mlagent _mLRight;
     private bool _mlMode;
    [SerializeField] private Rigidbody2D ball;
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
        
        leftChar.ResetPosition();
        if (_mlMode)
        {
            _mLRight.ResetPosition();
        }
        else
        {
            rightChar.ResetPosition();
        }
        ResetBall();
    }

    void Start()
    {
        leftChar = GameObject.Find("Left").GetComponent<Character>();

        ResetBall();
        _mLRight = GameObject.Find("MLright").GetComponent<Mlagent>();
        if (_mLRight != null)
        {
            _mlMode = true;
            return;
        }
        rightChar = GameObject.Find("Right").GetComponent<Character>();
    }

    private void  ResetBall()
    {
        ball.rotation = 0;
        ball.position = new Vector3(-0.2f, 0, 0);
        ball.velocity = new Vector3(0, 0, 0);
        ball.angularVelocity = 900;

    }

}