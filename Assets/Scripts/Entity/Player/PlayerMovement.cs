using UnityEngine;

    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private PlayerSettings playerSettings;
        [SerializeField] private CharacterController characterController;
        private Vector3 _moveVector;
        private float _fallVelocity;
        private Animator _animator;
        private AudioSource _audioSource;
        private static readonly int IsWalk = Animator.StringToHash("isWalk");
        private static readonly int IsJump = Animator.StringToHash("isJump");

        private void Awake()
        {
            _animator = GetComponentInChildren<Animator>();
            _audioSource = GetComponent<AudioSource>();
            characterController = GetComponent<CharacterController>();
        }

        private void OnEnable()
        {
            PlayerInput.OnMoveForward += Forward;
            PlayerInput.OnMoveLeft += Left;
            PlayerInput.OnMoveBack += Back;
            PlayerInput.OnMoveRight += Right;
            PlayerInput.OnJump += Jump;
        }

        private void Update()
        {
            _moveVector = Vector3.zero;

            if (Input.GetKey(KeyCode.W))
            {
                _moveVector += transform.forward;
            }
            if (Input.GetKey(KeyCode.S))
            {
                _moveVector -= transform.forward;
            }
            if (Input.GetKey(KeyCode.D))
            {
                _moveVector += transform.right;
            }
            if (Input.GetKey(KeyCode.A))
            {
                _moveVector -= transform.right;
            }

            //Jump
            if (Input.GetKeyDown(KeyCode.Space) && characterController.isGrounded)
            {
                _animator.SetTrigger(IsJump);
                _audioSource.PlayOneShot(SoundEvent.Clips[1]);
                _fallVelocity = -playerSettings.jumpForce;
            }
            
            if (_moveVector != Vector3.zero)
            {
                _animator.SetBool(IsWalk, true);
                if (!_audioSource.isPlaying)
                    _audioSource.PlayOneShot(SoundEvent.Clips[0]);
            }
            else
                _animator.SetBool(IsWalk, false);
        }

        private void StopPlayer()
        {
            _moveVector = Vector3.zero;
        }

        private void Forward()
        {
            _moveVector -= transform.forward;
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
            _animator.SetTrigger(IsJump);
            _audioSource.PlayOneShot(SoundEvent.Clips[1]);
            _fallVelocity = -playerSettings.jumpForce;
        }

        private void FixedUpdate()
        {
            Move();
            Gravity();
        }
        
        private void OnDisable()
        {
            PlayerInput.OnMoveForward -= Forward;
            PlayerInput.OnMoveLeft -= Left;
            PlayerInput.OnMoveBack -= Back;
            PlayerInput.OnMoveRight -= Right;
            PlayerInput.OnJump -= Jump;
        }

        private void Move()
        {
            characterController.Move(_moveVector * (playerSettings.speed * Time.fixedDeltaTime));
        }

        private void Gravity()
        {
            _fallVelocity += playerSettings.gravity * Time.fixedDeltaTime;
            characterController.Move(Vector3.down * (_fallVelocity * Time.fixedDeltaTime));
            if (characterController.isGrounded)
                _fallVelocity = 0;
        } 
    }