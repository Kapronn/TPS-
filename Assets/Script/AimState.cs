using UnityEngine;

public class AimState : MonoBehaviour
{
    [SerializeField] private float mouseSenseX = 1f;
    [SerializeField] private float mouseSenseY = 1f;
    private float _xAxis, _yAxis;
    [SerializeField] private Transform cameraFollow;

    void Update()
    {
        _xAxis += Input.GetAxisRaw("Mouse X") * mouseSenseX * Time.deltaTime;
        _yAxis -= Input.GetAxisRaw("Mouse Y") * mouseSenseY * Time.deltaTime;
        _yAxis = Mathf.Clamp(_yAxis, -80, 80);
    }

    private void LateUpdate()
    {
        cameraFollow.localEulerAngles = new Vector3(_yAxis, cameraFollow.localEulerAngles.y, cameraFollow.localEulerAngles.z);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, _xAxis, transform.eulerAngles.z);
    }
}