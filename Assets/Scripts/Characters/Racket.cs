using UnityEngine;

public class Racket : MonoBehaviour
{
    private Rigidbody2D _racketRigid ;
    [SerializeField] private float speed = 10.0f;
    private Vector3 _startPos;
    private Vector2 _startVel;
    private float _startrot;

    public float getRacketAngularVelocity()
    {
        return _racketRigid.angularVelocity;
    }

    public float getRacketRotation()
    {
        return _racketRigid.rotation % 360;
    }
    
    private void Start()
    {
        _racketRigid = gameObject.GetComponent<Rigidbody2D>();
        _startVel = _racketRigid.velocity;
        _startPos = _racketRigid.position;
        _startrot= _racketRigid.rotation;
    }

    public void Swing(float rot)
    {
        _racketRigid.AddForce(transform.right * (rot * speed), ForceMode2D.Impulse);
    }

    public void ResetPosRacket()
    {
        if (_racketRigid == null) return;
        _racketRigid.velocity = _startVel;
        _racketRigid.position = _startPos;
        _racketRigid.rotation = _startrot;

    }
}
