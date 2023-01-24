using UnityEngine;
using Cinemachine;

public class AimState : MonoBehaviour
{
    [SerializeField] AxisState xAxis, yAxis;
    [SerializeField] private Transform cameraFollow;

    void Start()
    {
    }


    void Update()
    {
        xAxis.Update(Time.deltaTime);
        yAxis.Update(Time.deltaTime);
    }

    private void LateUpdate()
    {
        cameraFollow.localEulerAngles = new Vector3(yAxis.Value, cameraFollow.localEulerAngles.y, cameraFollow.localEulerAngles.z);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, xAxis.Value, transform.eulerAngles.z);
    }
}