using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    // Paneeli, johon siirrytään kun tätä painiketta painetaan.
    public RectTransform NextPanel;

    public GameController GameController;

    /// <summary>
    /// Alla olevat julkiset muuttujat kertovat, miten paljon kyseistä asiaa lisätään GameControllerin saman nimisiin arvoihin kun kyseistä painiketta painetaan.
    /// Muuttujat ovat julkisia, jotta voidaan tarvittaessa editorin kautta helposti muuttaa näitä arvoja.
    /// </summary>
    public int KarmaMuutos = 0;
    public float RahaMuutos = 0;
    public int Viivytys = 0;
    public int PopcornitMuutos = 0;
    public int LeffaMuutos = 0;
    public int PulloaPotkaistuMuutos = 0;


    public void OnButtonPress()
    {
        GameController.Karma += KarmaMuutos;
        GameController.Raha += RahaMuutos;
        GameController.Viivytys += Viivytys;
        GameController.Popcorn += PopcornitMuutos;
        GameController.Leffa += LeffaMuutos;
        GameController.PulloaPotkaistu += PulloaPotkaistuMuutos;

        GameController.UpdateTexts();

        // Disabloidaan nykyinen paneeli ja aktivoidaan seuraava.
        transform.parent.gameObject.SetActive(false);
        NextPanel.gameObject.SetActive(true);
    }
}
