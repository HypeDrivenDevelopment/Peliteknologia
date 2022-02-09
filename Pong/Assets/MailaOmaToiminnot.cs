using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MailaOmaToiminnot : MonoBehaviour {
    //Mailan nopeus
    public float speed = 30;

    // Update is called once per frame
    void FixedUpdate () {
        //Otetaan mikä tahansa vertikaalinen syöte käyttäjältä
        float a = Input.GetAxisRaw("Vertical");
        //Liikutetaan mailaa syötteen suuntaan määrätyllä nopeudella
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, a) * speed;
    }
}
