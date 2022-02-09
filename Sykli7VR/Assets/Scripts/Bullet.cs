using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody rigidBody;
    public float speed = 2f;
    float lifeTime = 10f;
    
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other) {

    }
}
