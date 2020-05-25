using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using UnityEngine;

public class Mlagent : Agent
{
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private Racket charRacket;

    public GameObject ball;
    public bool invertX;
    public GameObject myArea;
    Rigidbody2D m_AgentRb;
    Rigidbody2D m_BallRb;
    float m_InvertMult;

    public override void Initialize()
    {
        m_BallRb = ball.GetComponent<Rigidbody2D>();
        m_AgentRb = GetComponentInChildren<Rigidbody2D>(); //Getting First child Be careful

    }
   
    private void ResetPosition()
    {
        m_AgentRb.velocity = new Vector3(0f, 0f, 0f);
        m_AgentRb.position = new Vector3(m_InvertMult*7f, 0f, 0f);
        charRacket.ResetPosRacket();

    }
    public override void OnEpisodeBegin()
    {
        m_InvertMult = invertX ? 1f : -1f;

        ResetPosition();
    }
    public override void CollectObservations(VectorSensor sensor)
    {
        var position = transform.position;
        var myAreaPosition = myArea.transform.position;
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
