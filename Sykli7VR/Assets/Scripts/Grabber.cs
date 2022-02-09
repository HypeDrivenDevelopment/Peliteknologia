using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabber : MonoBehaviour
{
    public enum Hand 
    {
        leftHand,
        rightHand
    }
    public Hand hand;
    public Transform grabbedObjectParent;
    private Grabbable grabbedObject;
    private Grabbable toBeGrabbed;

    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        // If you have something that should be grabbed and the grab is pressed
        // then make the grab happen here.
        // If the grab button is released then release the grab as well.

        // What do you have to do to make grab work? Do you make the object
        // follow the hand with some force? Do you just parent it to the hand?
        // Does your solution require changing the rigidbody properties?
        // There are many solutions to how to make it work.
    }

    private void OnTriggerEnter(Collider other) {
        // a good place to start would be to define something as toBeGrabbed here
        // and then making the actual interaction in update
    }
    
    private void OnTriggerExit(Collider other) {

    }
}
