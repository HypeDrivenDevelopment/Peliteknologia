using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PalloToiminnot : MonoBehaviour {

    //Pistemuuttujat tekstinä ja kokonaislukuina
    private int pisteetOma = 0;
    private int pisteetAI = 0;
    public Text tekstiPisteetOma;
    public Text tekstiPisteetAI;
    public static PalloToiminnot Instance;

    void Awake()
    {
        Instance = this;
    }

        // Use this for initialization
        void Start () {
        //Laitetaan viive pallon liikkumiselle pelin alkuun ja erien välille
        Invoke("PalloLiikkeelle", 3);
    }

    public bool PalloLiikkeelle()
    {
        //Luodaan pallon koordinaatit ja suuntavektori, sekä nopeus
        try
        {
            float speed = 15;
            GetComponent<Rigidbody2D>().position = new Vector2(0, 0);
            GetComponent<Rigidbody2D>().velocity = Vector2.one * speed;
        }
        catch (Exception e)
        {
            Debug.Log(e);
            return false;
        }
        return true;
    }

    //Pallon eventit. Oikea/vasen seinästä riippuen lisätään toisen pelaajan pisteitä ja muutetaan pistemäärä tekstimuotoon ja siirrytään alkuun.
    void OnTriggerEnter2D(Collider2D kohde)
    {
        if (kohde.tag == "SeinaVasen")
        {
            pisteetOma++;
            tekstiPisteetOma.text = pisteetOma.ToString();
            Start();
        }
        if (kohde.tag == "SeinaOikea")
        {
            pisteetAI++;
            tekstiPisteetAI.text = pisteetAI.ToString();
            Start();
        }
    }
}
