using System;
using UnityEngine;

public class AimStateManager : MonoBehaviour
{
    private AimBaseState _currentState;
    public HipState Hip = new HipState();
    public AimState Aim = new AimState();
    
    [SerializeField] private float mouseSenseX = 1f;
    [SerializeField] private float mouseSenseY = 1f;
    private float _xAxis, _yAxis;
    [SerializeField] private Transform cameraFollow;

    [HideInInspector] public Animator animator;
    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        SwitchState(Hip);
    }

    void Update()
    {
        _xAxis += Input.GetAxisRaw("Mouse X") * mouseSenseX * Time.deltaTime;
        _yAxis -= Input.GetAxisRaw("Mouse Y") * mouseSenseY * Time.deltaTime;
        _yAxis = Mathf.Clamp(_yAxis, -80, 80);
        
        _currentState.UpdateState(this);
    }

    private void LateUpdate()
    {
        cameraFollow.localEulerAngles = new Vector3(_yAxis, cameraFollow.localEulerAngles.y, cameraFollow.localEulerAngles.z);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, _xAxis, transform.eulerAngles.z);
    }

    public void SwitchState(AimBaseState state)
    {
        _currentState = state;
        _currentState.EnterState(this);
    }
}