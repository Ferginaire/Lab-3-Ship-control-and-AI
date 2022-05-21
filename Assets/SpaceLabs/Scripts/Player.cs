using UnityEngine;

public class Player : MonoBehaviour
{
    public float acceleration;
    public int maxSpeed;
    public float turnSpeed;

    private Rigidbody _rb;
    private float _forwardDir;
    private float _yawDir;
    private float _pitchDir;
    //private float _

    private void Start()
    {
        _rb = this.GetComponent<Rigidbody>();
    }
 
    private void FixedUpdate()
    {
        _forwardDir = Input.GetAxis("Vertical");
        
        // Move forward
        if ( _forwardDir > 0)
        {
            Throttle();
        }
        else
        {
            Decelerate();
        }
    }

    void Update(){
        _yawDir = Input.GetAxis("Mouse X");
        _pitchDir = Input.GetAxis("Mouse Y");

        transform.Rotate(_pitchDir * turnSpeed, _yawDir * turnSpeed, 0, Space.Self);
    }
    public void Throttle()
    {
         _rb.velocity += transform.forward * acceleration * Time.deltaTime;
    }


    public void Decelerate()
    {
        _rb.velocity = Vector3.Lerp(_rb.velocity, Vector3.zero, Time.deltaTime);
    }

}
