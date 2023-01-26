using System;
using UnityEngine;

public class FreezeAvatarLeave : MonoBehaviour
{
    private Transform _transform;

    private void Start()
    {
        _transform = FindObjectOfType<PlayerMovement>().transform;
    }

    void Update()
    {
        transform.position = _transform.position;
        transform.rotation = _transform.rotation;
    }
}
