using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MailaAIToiminnot : MonoBehaviour {
    //Mailan nopeus
    public float speed = 8;

    // Update is called once per frame
    void Update () {
        //Haetaan pallon ja mailan objektit
        var pallo = GameObject.Find("Pallo");
        var maila = GameObject.Find("MailaAI");
        //Jos molemmat löytyy niin otetaan niiden y-koordinaatit
        if (pallo && maila)
        {
            float palloY = pallo.transform.position.y;
            float mailaY = maila.transform.position.y;
            //Jos pallo on mailan yläpuolella, liikutetaan mailaa ylös, ja toisinpäin
            if (palloY > mailaY)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 1) * speed;
            }
            else
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, -1) * speed;
            }

        }
    }
}
