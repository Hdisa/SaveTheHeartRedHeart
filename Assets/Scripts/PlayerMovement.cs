using UnityEngine;


    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private PlayerSettings playerSettings;
        [SerializeField] private CharacterController characterController;
        private Vector3 _moveVector;
        private float _fallVelocity;

        private void OnEnable()
        {
            PlayerInput.OnMoveForward += Forward;
            PlayerInput.OnMoveLeft += Left;
            PlayerInput.OnMoveBack += Back;
            PlayerInput.OnMoveRight += Right;
            PlayerInput.OnJump += Jump;
        }

        private void Start()
        {
            characterController = GetComponent<CharacterController>();
        }

        private void Update()
        {
            _moveVector = Vector3.zero;
        }

        private void Forward()
        {
            _moveVector += transform.forward;
        }

        private void Left()
        {
            _moveVector -= transform.right;
        }

        private void Back()
        {
            _moveVector -= transform.forward;
        }

        private void Right()
        {
            _moveVector += transform.right;
        }

        private void Jump()
        {
            _fallVelocity = -playerSettings.jumpForce;
        }

        private void FixedUpdate()
        {
            characterController.Move(_moveVector * (playerSettings.speed * Time.fixedDeltaTime));

            _fallVelocity += playerSettings.gravity * Time.fixedDeltaTime;
            characterController.Move(Vector3.down * (_fallVelocity * Time.fixedDeltaTime));
            if (characterController.isGrounded)
                _fallVelocity = 0;
        }
    }