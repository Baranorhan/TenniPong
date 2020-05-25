using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AiMedium : Character
{
    // Start is called before the first frame update
    [SerializeField]
    private Rigidbody2D ball;
    private float _ballx;
    private float _bally;
    private float _balldirection;
    private Vector2 _direction = new Vector2(0, 0);

    private void FixedUpdate()
    {
        var position = ball.position;
        _ballx = position.x;
        _bally = position.y;
        _balldirection = ball.velocity.x;

        if (Mathf.Abs(_bally - CharRigid.position.y) < 0.4f)
            _direction.y = 0;

        else if (_bally>CharRigid.position.y)
        {
                _direction.y = 1;
        }
        else
        {
            _direction.y = -1;
        }
        if (_ballx < 0 ) // Top karşı sahada
        {
            if (CharRigid.position.x < 7.1f) // arkada bekle 
                _direction.x = 1;
            else
                _direction.x = 0;

        }
        else if (_ballx > 0 && _balldirection < 0.7f) // Top sahada ve yavaş
        {
            if (_ballx > CharRigid.position.x) //top arkada
                _direction.x = 1;
            else
                _direction.x = -0.2f;

        }

    }
    private void LateUpdate()
    {

        if (Mathf.Abs(_ballx - CharRigid.position.x) <2)
        {
            if (Mathf.Abs(_bally - CharRigid.position.y) < 1)
            {
                if(CharRigid.position.y<0)
                    charRacket.Swing(+1);
                else
                    charRacket.Swing(-1);

                Debug.Log("hi");
            }
        }
        
        CharRigid.AddForce(_direction * speed, ForceMode2D.Impulse);

    }
}
