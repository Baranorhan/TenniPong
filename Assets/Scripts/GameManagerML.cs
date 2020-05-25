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
    
    public void Goal(GoalGate wall)
    {
        if (wall.name.Equals("LeftCollider"))
        {
            _scoreLeft += 1;
            m_AgentB.SetReward(1f);
            m_AgentA.SetReward(-1f);
        }
        else
        {
            _scoreRight += 1;
            m_AgentA.SetReward(1f);
            m_AgentB.SetReward(-1f);
        }

        _score.text = _scoreLeft + "         " + _scoreRight;
        
        m_AgentA.EndEpisode();
        m_AgentB.EndEpisode();
        ResetBall();
    }


    private void  ResetBall()
    {
        ball.rotation = 0;
        ball.position = new Vector3(0f, 0, 0);
        ball.velocity = new Vector3(0, 0, 0);

    }
}
