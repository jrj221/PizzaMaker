using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Rigidbody _rb;
    private Vector3 _moveDirection;
    private Vector3 _velocitySmoothing = Vector3.zero;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }
    
    private void FixedUpdate()
    {
        MovePlayer();
        CapSpeed();
    }

    private void MovePlayer()
    {
        Vector3 inputMoveDirection = InputManager.Instance.InputMoveDirection;
        _moveDirection = Vector3.ProjectOnPlane(inputMoveDirection.x * transform.right + inputMoveDirection.y * transform.forward, Vector3.up).normalized;
        // _rb.AddForce(10f * _speed * _moveDirection);
        _rb.linearVelocity = Vector3.SmoothDamp(_rb.linearVelocity, 
                                                _moveDirection * _speed,  
                                                ref _velocitySmoothing, 
                                                0.05f);
    }
    

    private void CapSpeed()
    {
        if (_rb.linearVelocity.magnitude > _speed)
        {
            _rb.linearVelocity = _moveDirection * _speed;
        }
    }
}
