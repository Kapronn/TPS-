
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float currentMoveSpeed;
    public float walkSpeed, walkBackSpeed;
    public float runSpeed, runBackSpeed;
    public float crouchSpeed, crouchBackSpeed;
    
    private CharacterController _characterController;
    public float HorizontalInput { get; private set; } 
    public float VerticalInput { get; private set; }
    [HideInInspector] public Vector3 direction;

    [Header("Grounding")]
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float sphereToGround;
    private Vector3 _spherePosition;

    [Header("Gravity")]
    [SerializeField] private float gravity = -9.81f;
    private Vector3 _velocity;

    [Header("States")]
    private MovementBaseState _currentState;

    public IdleState IdleState = new IdleState();
    public WalkingState WalkingState= new WalkingState();
    public RunningState RunningState = new RunningState();
    public CrouchingState CrouchingState = new CrouchingState();
    [HideInInspector] public Animator animator;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        _characterController = GetComponent<CharacterController>();
        SwitchState(IdleState);
    }


    void Update()
    {
        CreateDirectionOfMovement();
        Gravity();
        
        animator.SetFloat("HorizontalInput", HorizontalInput);
        animator.SetFloat("VerticalInput", VerticalInput);
        
        _currentState.UpdateState(this);
    }
    

    public void SwitchState(MovementBaseState state)
    {
        _currentState = state;
        _currentState.EnterState(this);
    }
    private void CreateDirectionOfMovement()
    {
        HorizontalInput = Input.GetAxis("Horizontal");
        VerticalInput = Input.GetAxis("Vertical");
        direction = transform.forward * VerticalInput + transform.right * HorizontalInput;
        _characterController.Move(direction.normalized * (Time.deltaTime * currentMoveSpeed));
    }

    bool IsGrounded()
    {
        _spherePosition = new Vector3(transform.position.x, transform.position.y - sphereToGround, transform.position.z);
        if (Physics.CheckSphere(_spherePosition, _characterController.radius - 0.05f, groundMask)) return true;
        return false;
    }

    void Gravity()
    {
        if (!IsGrounded()) _velocity.y += gravity * Time.deltaTime;
        else if (_velocity.y < 0) _velocity.y = -2;

        _characterController.Move(_velocity * Time.deltaTime);
    }
}