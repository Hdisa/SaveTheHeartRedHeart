using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float gravity = 9.8f;
    [SerializeField] private float jumpForce = 10;
    [SerializeField] private float speed = 10;
    private CharacterController _characterController;
    private float _fallVelocity;
    private Vector3 _moveVector;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        _moveVector = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
            _moveVector += transform.forward;
        if (Input.GetKey(KeyCode.A))
            _moveVector -= transform.right;
        if (Input.GetKey(KeyCode.S))
            _moveVector -= transform.forward;
        if (Input.GetKey(KeyCode.D))
            _moveVector += transform.right;
        if (Input.GetKeyDown(KeyCode.Space) && _characterController.isGrounded)
            _fallVelocity = -jumpForce;
    }

    void FixedUpdate()
    {
        _characterController.Move(_moveVector * (speed * Time.fixedDeltaTime));
        _fallVelocity += gravity * Time.fixedDeltaTime;
        _characterController.Move(Vector3.down * (_fallVelocity * Time.fixedDeltaTime));
        
        if (_characterController.isGrounded)
            _fallVelocity = 0;
    }
}
