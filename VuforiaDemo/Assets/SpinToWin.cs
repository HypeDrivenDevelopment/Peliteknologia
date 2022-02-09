using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinToWin : MonoBehaviour {

    // Pyörimisen nopeus
    int Speed = 100;
	
	void Update () {
        // Joka updatella pallon y-akselin rotaatiota muutetaan hieman.
        transform.Rotate(new Vector3(0, Time.deltaTime * Speed, 0));
	}
}
