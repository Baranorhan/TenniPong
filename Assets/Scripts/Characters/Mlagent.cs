using System;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using UnityEngine;

public class Mlagent : Agent
{
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private Racket charRacket;

    public GameObject ball;
    public bool invertX;
    public Transform myArea;
    private Rigidbody2D _mAgentRb;
    private Rigidbody2D _mBallRb;
    private float _mInvertMult;
    private float _reward;

    public override void Initialize()
    {
        _mBallRb = ball.GetComponent<Rigidbody2D>();
        _mAgentRb = GetComponentInChildren<Rigidbody2D>(); //Getting First child Be careful

    }
   
    public void ResetPosition()
    {
        var myAreaPosition = myArea.position;
        _mAgentRb.velocity = new Vector3(0f, 0f, 0f);
        _mAgentRb.position = new Vector3(myAreaPosition.x+ _mInvertMult*7f,
                                            myAreaPosition.y, 
                                            myAreaPosition.z);
        charRacket.ResetPosRacket();

    }

    public override void Heuristic(float[] actionsOut)
    {
        actionsOut[0] = -Input.GetAxis("Horizontal");     
        actionsOut[1] = -Input.GetAxis("Vertical");
        actionsOut[2] = Input.GetAxis("Racket");
    }

    
    public override void OnEpisodeBegin()
    {
        _mInvertMult = invertX ? 1f : -1f;
        if (invertX)
            BallResetAgent();
        ResetPosition();
    }

    private void BallResetAgent()
    {
        _mBallRb.rotation = 0;
        _mBallRb.position = myArea.position;
        _mBallRb.velocity = new Vector3(-1, 0, 0);

        }    

    private void Update()
    {            
        //character range  -5 to 5
        // reward agent if its near the ball but not too near
        var distanceBetweenBall = _mBallRb.position.y - _mAgentRb.position.y;
        // reward character for sending ball to other side
        var ballSpeed = _mInvertMult * _mBallRb.velocity.x;

        if (ballSpeed > 4f)
        {            
            _reward += ballSpeed/10000;    // max 20 speed 0.02 Reward
            Debug.Log(_reward);

        }
        
        if (Math.Abs(distanceBetweenBall) > 1)// don't reward if ball is too near
        
        
        
        //_reward += Mathf.Lerp(0.01f, 0,distanceBetweenBall/5);
        SetReward(_reward);
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        var position = transform.position;
        var myAreaPosition = myArea.position;
        var ballPosition = _mBallRb.position;

        sensor.AddObservation(_mInvertMult * (position.x - myAreaPosition.x));
        
        sensor.AddObservation(position.y - myAreaPosition.y);
        sensor.AddObservation(_mInvertMult * _mAgentRb.velocity.x);
        sensor.AddObservation(_mAgentRb.velocity.y);

        sensor.AddObservation(_mInvertMult * (ballPosition.x - myAreaPosition.x));
        sensor.AddObservation(ballPosition.y - myAreaPosition.y);
        sensor.AddObservation(_mInvertMult * _mBallRb.velocity.x);
        sensor.AddObservation(_mBallRb.velocity.y);
        
        sensor.AddObservation(_mInvertMult * charRacket.getRacketRotation());
        sensor.AddObservation(_mInvertMult * charRacket.getRacketAngularVelocity());
        
    }
    
    public override void OnActionReceived(float[] vectorAction)
    {
        var moveX = Mathf.Clamp(vectorAction[0], -1f, 1f) * _mInvertMult;
        var moveY = Mathf.Clamp(vectorAction[1], -1f, 1f);
        var swing = Mathf.Clamp(vectorAction[2], -1f, 1f) * _mInvertMult;

            _mAgentRb.AddForce(new Vector2(_mInvertMult * moveX,moveY) * speed, ForceMode2D.Impulse);
        charRacket.Swing(swing);
    }
    
}
