using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunReturner : MonoBehaviour
{
    private Grabbable grabbable;
    private float returnTimer;
    public float returnTime = 2f;
    public Transform gunRack;
    private Rigidbody rigidBody;
    void Start()
    {
        grabbable = GetComponent<Grabbable>();
        rigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Figure out if the gun is grabbed and if not...
    }
}
