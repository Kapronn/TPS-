using System;
using Cinemachine;
using UnityEngine;

public class AimStateManager : MonoBehaviour
{
    private AimBaseState _currentState;
    public HipState Hip = new HipState();
    public AimState Aim = new AimState();
    
    [Header("Camera rotation")]
    [SerializeField] private float mouseSenseX = 1f;
    [SerializeField] private float mouseSenseY = 1f;
    [SerializeField] private Transform cameraFollow;
    [HideInInspector] public Animator animator;
    private float _xAxis, _yAxis;

    [Header("CineMacine Camera")]
    [HideInInspector] public CinemachineVirtualCamera virtualCamera;
    [HideInInspector] public float currentFov;
    [HideInInspector] public float hipFov;
    public float adsFov = 40f;
    public float fovSmoothSpeed = 10f;

    [Header("Aim")]
    public Transform aimPos;
    [HideInInspector] public Vector3 actualAimPos;
    [SerializeField] private float aimSmoothSpeed = 20;
    [SerializeField] private LayerMask aimMask;
    private void Start()
    {
        virtualCamera = GetComponentInChildren<CinemachineVirtualCamera>();
        hipFov = virtualCamera.m_Lens.FieldOfView;
        
        animator = GetComponent<Animator>();
        SwitchState(Hip);
    }

    void Update()
    {
        _xAxis += Input.GetAxisRaw("Mouse X") * mouseSenseX * Time.deltaTime;
        _yAxis -= Input.GetAxisRaw("Mouse Y") * mouseSenseY * Time.deltaTime;
        _yAxis = Mathf.Clamp(_yAxis, -80, 80);

        virtualCamera.m_Lens.FieldOfView = Mathf.Lerp(virtualCamera.m_Lens.FieldOfView, currentFov, fovSmoothSpeed * Time.deltaTime);
        _currentState.UpdateState(this);
        
        Vector2 screenCenter = new Vector2(Screen.width/2.3f, Screen.height/2f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenter);
        if(Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, aimMask ))
        {
            aimPos.position = Vector3.Lerp(aimPos.position, hit.point, aimSmoothSpeed * Time.deltaTime);
            actualAimPos = hit.point;
        }
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