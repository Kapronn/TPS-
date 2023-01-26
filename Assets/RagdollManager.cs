using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollManager : MonoBehaviour
{
    private Rigidbody[] _rigidbodies;
    void Start()
    {
        _rigidbodies = GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody rigidbody in _rigidbodies) rigidbody.isKinematic = true;

    }

    public void TriggerRagdoll()
    {
        foreach (Rigidbody rigidbody in _rigidbodies) rigidbody.isKinematic = false; 
    }
}
