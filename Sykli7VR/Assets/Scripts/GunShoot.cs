using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShoot : MonoBehaviour
{
    private Grabbable grabbable;
    public GameObject bullet;
    public Transform bulletSpawn;

    void Start()
    {
        grabbable = GetComponent<Grabbable> ();
    }

    void Update()
    {
        // Remember to check which hand is holding the gun so you know
        // what input should be used for shooting.
    }
}
