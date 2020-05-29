using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using UnityEngine;
using Random = System.Random;

public class Mlagent : Agent
{
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private Racket charRacket;

    public GameObject ball;
    public bool invertX;
    public Transform myArea;
    Rigidbody2D m_AgentRb;
    Rigidbody2D m_BallRb;
    float m_InvertMult;
    private float reward;

    public override void Initialize()
    {
        m_BallRb = ball.GetComponent<Rigidbody2D>();
        m_AgentRb = GetComponentInChildren<Rigidbody2D>(); //Getting First child Be careful

    }
   
    private void ResetPosition()
    {
        var myAreaPosition = myArea.position;
        m_AgentRb.velocity = new Vector3(0f, 0f, 0f);
        m_AgentRb.position = new Vector3(myAreaPosition.x+ m_InvertMult*7f,
                                            myAreaPosition.y, 
                                            myAreaPosition.z);
        charRacket.ResetPosRacket();

    }
    public override void OnEpisodeBegin()
    {
        m_InvertMult = invertX ? 1f : -1f;
        if (invertX)
            BallResetAgent();
        ResetPosition();
    }

    private void BallResetAgent()
    {
        m_BallRb.rotation = 0;
        m_BallRb.position = myArea.position;
        m_BallRb.velocity = new Vector3(-1, 0, 0);

        }    

    private void Update()
    {
        //character range  -5 to 5
        // reward agent if its near the ball but not too near
        var distanceBetweenBall = ball.transform.position.y - m_AgentRb.position.y;

        if (Math.Abs(distanceBetweenBall) < 1)
        {
            reward = 0;
            return ; // don't want ball too close
        }
        
        reward = Mathf.Lerp(0.1f, 0,distanceBetweenBall/5);
        AddReward(reward);
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        var position = transform.position;
        var myAreaPosition = myArea.position;
        var ballPosition = ball.transform.position;

        sensor.AddObservation(m_InvertMult * (position.x - myAreaPosition.x));
        
        sensor.AddObservation(position.y - myAreaPosition.y);
        sensor.AddObservation(m_InvertMult * m_AgentRb.velocity.x);
        sensor.AddObservation(m_AgentRb.velocity.y);

        sensor.AddObservation(m_InvertMult * (ballPosition.x - myAreaPosition.x));
        sensor.AddObservation(ballPosition.y - myAreaPosition.y);
        sensor.AddObservation(m_InvertMult * m_BallRb.velocity.x);
        sensor.AddObservation(m_BallRb.velocity.y);
        
        sensor.AddObservation(m_InvertMult * charRacket.getRacketRotation());
        sensor.AddObservation(m_InvertMult * charRacket.getRacketAngularVelocity());
        
    }
    
    public override void OnActionReceived(float[] vectorAction)
    {
        var moveX = Mathf.Clamp(vectorAction[0], -1f, 1f) * m_InvertMult;
        var moveY = Mathf.Clamp(vectorAction[1], -1f, 1f);
        var swing = Mathf.Clamp(vectorAction[2], -1f, 1f) * m_InvertMult;

            m_AgentRb.AddForce(new Vector2(m_InvertMult * moveX,moveY) * speed, ForceMode2D.Impulse);
        charRacket.Swing(swing);
    }
    
}
