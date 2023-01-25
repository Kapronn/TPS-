using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    void Start()
    {
        Destroy(gameObject, 4f);
    }

    private void OnCollisionEnter(Collision other)
    { 
        Destroy(gameObject);
       Debug.Log(other.gameObject.name);
    }
}
