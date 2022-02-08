using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private GameObject player;

    /// <summary>
    /// Siirtää pelaajan katsotun kohteen yläpuolelle.
    /// </summary>
    public void Teleport()
    {
        // Haetaan kohteen paikkavektori ja puretaan se.
        var vektori = transform.localPosition;
        var x = vektori.x;
        var y = vektori.y;
        var z = vektori.z;

        // Haetaan pelaajan gameobjecti ja muutetaan sen paikkavektori hieman kohteen yläpuolelle.
        player = GameObject.Find("Player");
        player.transform.localPosition = new Vector3(x, y+5, z);
    }
}
