using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbable : MonoBehaviour
{
    public enum GrabbableType 
    {
        basic,
        oriented,
        placeable
    }

    public GrabbableType type;
    public Transform grabbedOrientation;
    public Grabber grabbedBy;
    public Transform toBePlaced;
    public Collider placementTarget;
    public Rigidbody rigidBody;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        
    }
}
