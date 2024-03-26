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
        }

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
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            characterController = GetComponent<CharacterController>();
        }

        private void Update()
        {
            if (_moveVector != Vector3.zero)
            {
                _animator.SetBool(IsWalk, true);
                _audioSource.PlayOneShot(Player.Clips[0]);
            }
            else
                _animator.SetBool(IsWalk, false);
            
            StopPlayer();
        }

        private void StopPlayer() => _moveVector = Vector3.zero;

        private void Forward() => _moveVector += transform.forward;

        private void Left() => _moveVector -= transform.right;

        private void Back() => _moveVector -= transform.forward;

        private void Right() => _moveVector += transform.right;

        private void Jump()
        {
            _animator.SetTrigger(IsJump);
            _audioSource.PlayOneShot(Player.Clips[1]);
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

        private void Move() => characterController.Move(_moveVector * (playerSettings.speed * Time.fixedDeltaTime));

        private void Gravity()
        {
            _fallVelocity += playerSettings.gravity * Time.fixedDeltaTime;
            characterController.Move(Vector3.down * (_fallVelocity * Time.fixedDeltaTime));
            if (characterController.isGrounded)
                _fallVelocity = 0;
        } 
    }