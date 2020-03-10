using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiMedium : Character
{
    // Start is called before the first frame update
    public Rigidbody2D Ball;
    private float _Ballx;
    private float _Bally;
    private float _Balldirection;
    Vector2 _direction = new Vector2(0, 0);

    private void FixedUpdate()
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
        if (_Ballx < 0 ) // Top karşı sahada
        {
            if (CharRigid.position.x < 7.1f) // arkada bekle 
                _direction.x = 1;
            else
                _direction.x = 0;

        }
        else if (_Ballx > 0 && _Balldirection < 0.7f) // Top sahada ve yavaş
        {
            if (_Ballx > CharRigid.position.x) //top arkada
                _direction.x = 1;
            else
                _direction.x = -0.2f;

        }

    }
    private void LateUpdate()
    {


        Debug.Log(Mathf.Abs(_Ballx - CharRigid.position.x)+"hi" +Mathf.Abs(_Bally - CharRigid.position.y));
        if (Mathf.Abs(_Ballx - CharRigid.position.x) <2 && Mathf.Abs(_Bally - CharRigid.position.y) < 1)// Swing Time{
        {
            if(CharRigid.position.y<0)
            CharRacket.Swing(+1);
            else
                CharRacket.Swing(-1);

            Debug.Log("hi");
        }
        CharRigid.AddForce(_direction * speed, ForceMode2D.Impulse);

    }
}
