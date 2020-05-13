using UnityEngine;

public class Racket : MonoBehaviour
{
    private Rigidbody2D _racketRigid;
    [SerializeField] private float speed = 10.0f;
    private Vector3 _startVel, _startPos;
    private float _startrot;

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
        _racketRigid.velocity = _startVel;
        _racketRigid.position = _startPos;
        _racketRigid.rotation = _startrot;

    }
}
