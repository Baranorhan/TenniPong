using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Text leftScore;
    [SerializeField] private Text rightScore;
    [SerializeField] private Character leftChar, rightChar;
    [SerializeField] private Rigidbody2D ball;
    [SerializeField] private Canvas canvas;
    public void Goal(GoalGate wall)
    {
        if (wall.name.Equals("LeftCollider"))
            leftScore.text = (int.Parse(leftScore.text) + 1).ToString();
        else
            rightScore.text = "     "+(int.Parse(rightScore.text) + 1).ToString();

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
