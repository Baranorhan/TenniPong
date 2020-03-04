using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiMedium : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject RacketAi;
    public Rigidbody2D CharRigid;
    public float speed = 25f;
    public Rigidbody2D Ball;
    private float _Ballx;
    private float _Bally;
    private float _Balldirection;
    Vector2 _direction = new Vector2(0, 0);


    // Update is called once per frame
    private void Update()
    {
        _Ballx = Ball.position.x;
        _Bally = Ball.position.y;
        _Balldirection = Ball.velocity.x;

        if (Mathf.Abs(_Bally - CharRigid.position.y) < 0.4f)
            _direction.y = 0;

        else if (_Bally>CharRigid.position.y)
        {
                _direction.y = 1;
        }
        else
            {
                _direction.y = -1;
            };
        if (_Ballx < 0 && CharRigid.position.x < 7) // Top karşı sahada
        {
            if (CharRigid.position.x > 6.7f)
                _direction.x = 0.1f;
            else
                _direction.x = 1;

        }
        else if (_Ballx > 0 && _Balldirection > 0.7f) // Top sahada ve yavaş
            if (_Ballx < CharRigid.position.x) //top arkada
                _direction.x = -1;
        else
            _direction.x = 1;

        else _direction.x = 0;



    }
    private void FixedUpdate()
    {

        CharRigid.AddForce(_direction * speed, ForceMode2D.Impulse);

    }
}
