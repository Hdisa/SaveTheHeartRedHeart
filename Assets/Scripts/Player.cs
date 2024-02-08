using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]private PlayerSettings playerSettings;
    private CharacterController _characterController;
    private float _fallVelocity;
    private Vector3 _moveVector;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        ControllerInput();
    }

    void FixedUpdate()
    {
        PhysicalMovement();
    }
    
    private void ControllerInput()
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
            _fallVelocity = -playerSettings.jumpForce;
    }

    private void PhysicalMovement()
    {
        _characterController.Move(_moveVector * (playerSettings.speed * Time.fixedDeltaTime));
        _fallVelocity += playerSettings.gravity * Time.fixedDeltaTime;
        _characterController.Move(Vector3.down * (_fallVelocity * Time.fixedDeltaTime));
        
        if (_characterController.isGrounded)
            _fallVelocity = 0;
    }
}
