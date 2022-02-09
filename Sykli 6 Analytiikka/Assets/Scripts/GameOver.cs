using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Tämä skripti on GameOver-paneelissa ja lähinnä tekee vain kivat lopputekstit GameOver-paneeliin.
/// </summary>
public class GameOver : MonoBehaviour
{
    public GameController GameController;
    public string gameOverText;
    private Scene thisScene;

    private void OnEnable()
    {

        // Jos pelaaja potkaisi pulloa
        if (GameController.PulloaPotkaistu > 0)
        {
            gameOverText =
                "Yrität potkaista pullon piiloon, mutta liukastut ja nyrjäytät nilkkasi. Vietät loppuillan terveyskeskuksessa.\n Karmasi oli: " + GameController.Karma;

            GetComponentInChildren<Text>().text = gameOverText;
            SendData();
            return;
        }

        // Leffalippu ja popcorn keissit
        if (GameController.Leffa == 1 && GameController.Popcorn == 1 && GameController.Raha >= 0 && GameController.Viivytys < 3)
        {
            gameOverText = "Nautit elokuvasta.";
        }
        else if (GameController.Leffa == 1 && GameController.Popcorn == 0 && GameController.Raha >= 0 && GameController.Viivytys < 3)
        {
            gameOverText = "Elokuva oli hyvä, mutta naposteltavat jäivät sivu suun.";
        }
        else if (GameController.Leffa == 0 && GameController.Popcorn == 1)
        {
            gameOverText = "Et nähnyt elokuvaa. Kävelet kotiin syöden samalla popcorneja.\n Karmasi oli: " + GameController.Karma;

            GetComponentInChildren<Text>().text = gameOverText;
            SendData();
            return;
        }
        else if (GameController.Leffa == 0)
        {
            gameOverText = "Et nähnyt elokuvaa.";
        }

        // Jos pelaaja kestää liian kauan
        if (GameController.Viivytys >= 3)
        {
            gameOverText = gameOverText +
                " Sinulla kesti matkassa niin kauan, että kerkesit elokuvasaliin vain nähdäksesi elokuvan lopun ja elokuva on nyt spoilattu.";
        }

        // Jos pelaajan rahat loppuivat, joudutaan lainaamaan kaverilta
        if (GameController.Raha < 0)
        {
            GameController.Karma -= 1;
            gameOverText = gameOverText +
                " Jouduit lainaamaan kaveriltasi rahaa elokuvalippuun, eikä kaverisi päässyt elokuviin. Hän on nyt sinulle vihainen.";
        }

        // Jos on popcorneja
        if (GameController.Popcorn == 1)
        {
            gameOverText = gameOverText + " Popcornit maistuvat hyvälle.";
        }

        // Karman näyttäminen
        gameOverText = gameOverText + "\n Karmasi oli: " + GameController.Karma;

        GetComponentInChildren<Text>().text = gameOverText;

        // Pelin päätyttyä tallennetaan pelaajan hidden karma.
        GameController.UpdateHiddenKarma();

        SendData();
    }

    /// <summary>
    /// Pelin päättyessä lähetetään suorituksesta dataa analysoitavaksi.
    /// </summary>
    private void SendData()
    {
        // Haetaan get-metodilla (lisäsin itse) pelaajan hidden karma.
        int HiddenKarma;
        HiddenKarma = GameController.GetHiddenKarma();

        // Haetaan aktiivinen scene.
        thisScene = SceneManager.GetActiveScene();

        // Lisätään parametridictiin pelin lopussa saadut pelattu aika, karma, raha ja piilokarma.
        Dictionary<string, object> customParams = new Dictionary<string, object>();
        customParams.Add("pelattu_aika", GameController.PelattuAika);
        customParams.Add("karma", GameController.Karma);
        customParams.Add("raha", GameController.Raha);
        customParams.Add("piilo_karma", HiddenKarma);

        // Käytetään datan lähetykseen valmista LevelComplete metodia, joka ottaa parametreina 
        // scenen nimen, indeksin, sekä valitut custom-parametrit.
        AnalyticsEvent.LevelComplete(thisScene.name, thisScene.buildIndex, customParams);

        //AnalyticsResult result = Analytics.CustomEvent("Test");
        // This should print "Ok" if the event was sent correctly.
        //Debug.Log(result);
    }

    
}
