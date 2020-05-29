using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;

public class GameManagerML : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _score;
    private int _scoreLeft = 0, _scoreRight = 0 ;
    [SerializeField] private Mlagent m_AgentA;
    [SerializeField] private Mlagent m_AgentB;
    [SerializeField] private Rigidbody2D ball; 
    [SerializeField] private Transform _trainArea;

    private void Start()
    {
        ResetBall(-1);
    }

    public void Goal(GoalGate wall)
    {
        var isLeftScored = -1;
        if (wall.name.Equals("LeftCollider"))
        {
            _scoreLeft += 1;
            isLeftScored = 1;
        }
        else
            _scoreRight += 1;
      
        m_AgentB.SetReward(-isLeftScored);
        m_AgentA.SetReward(isLeftScored);
        
        _score.text = _scoreLeft + "         " + _scoreRight;
        
        m_AgentA.EndEpisode();
        m_AgentB.EndEpisode();
        ResetBall(isLeftScored);
    }


    private void  ResetBall(int isleftScored)
    {
        ball.rotation = 0;
        ball.position = _trainArea.position;
        ball.velocity = new Vector3(-isleftScored, 0, 0);

    }
}
