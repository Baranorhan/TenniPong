using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Text LeftScore, RightScore;
    public Character LeftChar, RightChar;
    public Rigidbody2D Ball;
    public Canvas canvas;
    public void Goal(GoalGate Wall)
    {
        if (Wall.name.Equals("LeftCollider"))
            LeftScore.text = (int.Parse(LeftScore.text) + 1).ToString();
        else
            RightScore.text = "     "+(int.Parse(RightScore.text) + 1).ToString();

        LeftChar.ResetPosition();
        RightChar.ResetPosition();
        ResetBall();


    }

    // Start is called before the first frame update
    void Start()
    {
        ResetBall();
    }

   private void  ResetBall()
    {
        Ball.rotation = 0;
        Ball.position = new Vector3(-0.2f, 0, 0);
        Ball.velocity = new Vector3(0, 0, 0);
        Ball.angularVelocity = 900;

    }

}
