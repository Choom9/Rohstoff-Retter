using UnityEngine;

using TMPro;

using System.Collections;

using UnityEngine.UI;
public class DialogManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        ShellyREDE = Shelly.GetComponent<Animator>();
        StartCoroutine(DialogUiAktivierenNachStart());
    }

     public Animator ShellyREDE;

    public GameObject Shelly;

    public GameObject DialogUiKomplett;
    public TextMeshProUGUI SprechblaseText;

    public GameObject Weiterbutton;

    public Button Weiter;

    //Merken welche CoRoutine gerade läuft
    Coroutine aktuelleSchreibCoroutine;

    // Shelly und Sprechblase erscheinen erst nach 2 Sekunden, mit Coroutine machen, DialogUI aktivieren (eigebtlich deaktiviert)

    IEnumerator DialogUiAktivierenNachStart()
    {

        yield return new WaitForSeconds(1.5f);
        DialogUiKomplett.SetActive(true);
        
        // startet Co Routine UND speichert sie

        //Verhindert doppelte Coroutine
        if (aktuelleSchreibCoroutine != null)
        {

            StopCoroutine(aktuelleSchreibCoroutine);

        }

        aktuelleSchreibCoroutine = StartCoroutine(SchreibEffekt(dialoge1[dialogZaehler]));
        DialogSpielen();
        dialogZaehler++;
         


    }


    // Funktion für Dialog spielen mit DialogZaehler Variable 
    public void DialogSpielen()
    {
        SoundManager.Instance.voiceOverPlayer.clip = SoundManager.Instance.dialogVoiceOvers[dialogZaehler];
        SoundManager.Instance.voiceOverPlayer.Play();
    }


    string[] dialoge1 = new string[]
         {
        //0 Keine ahnung was das ist aber 0 wird einfach nicht angezeigt 
        "Komm, lass uns direkt hier im Sand anfangen, wo das Netz lag. Wir fangen mit dem an, was am hellsten funkelt: dem Glas.",


        //1
        "Man kann es einschmelzen und daraus immer wieder neue Flaschen machen, ohne dass es an Qualität verliert. Das spart nicht nur riesige Mengen an Energie, sondern schont auch unseren wertvollen Sand hier auf der Erde.",

        //2
        "Hilfst du mir, zuerst alle Glasobjekte aus dem Haufen herauszusuchen?",

        //3
        "Achte auf deinen Recycling-Balken oben. Er zeigt dir an, wie viel Glas wir schon gerettet haben. Aber pass auf: Nur leere Flaschen und Einkochgläser dürfen in die Container!",

        //4
         "Wow, großartig! Schau nur, wie der Strand ohne das ganze Glas schon viel sauberer wirkt. Das hast du toll gemacht!",

        //5
         "Und weißt du, was das Beste ist? Die Flaschen, die du gerade gesammelt hast, werden jetzt gewaschen, eingeschmolzen und zu funkelneuen Gläsern verarbeitet. Durch deine Hilfe konnte so super viel Energie gespart werden.", 

        //6
          "Aber wir sind noch nicht fertig. Jetzt, wo das ganze Glas weg ist, sehe ich die alten Bananenschalen und Apfelreste die hier herumliegen viel deutlicher. Wir müssen sie schnell einsammeln und in die Biotonne werfen, bevor noch jemand darauf ausrutscht.",

         };


    string[] HinweisUITextText = new string[]
    {
    //0 
    "Hinweis:\nLass deinen Zeiger über einem Müllobjekt schweben, drücke die linke Maustaste, halte diese gedrückt, und bewege deine Maus. Wenn der Müll über dem Container schwebt, lasse die linke Maustaste los.",

    };



public bool textTeilFertig;
    // damit text generierungs effekt entsteht wird der text quasi buchstabe für buchstabe gebaut mit Zeit verzögerung
    IEnumerator SchreibEffekt(string Text)
    {

        SprechblaseText.text = "";
        textTeilFertig = false;
        ShellyREDE.SetBool("ShellyREDEBool", true);
        Weiter.interactable = false;
        Debug.Log(ShellyREDE.GetBool("ShellyREDEBool"));

        foreach (char buchstabe in Text)
        {

            SprechblaseText.text += buchstabe;

            yield return new WaitForSeconds(0.057f);

            

        }
        textTeilFertig = true;
         ShellyREDE.SetBool("ShellyREDEBool", false);
         Weiter.interactable = true;
         Debug.Log(ShellyREDE.GetBool("ShellyREDEBool"));

    }


    //Zugriff auf text SprechblaseText.text = "Hallo!";
    //Funktion für weiter button fehlt 
    // ä mit ae ersetzen 
    public int dialogZaehler = 0;


    void naechsterDialogWeiter()
    { 
            if (dialogZaehler == 4 && DialogUiKomplett.activeSelf && GameManager.Instance.anzahlRichtigerSortierungen < 10)
        {
            SoundManager.Instance.voiceOverPlayer.Stop();
            DialogUiKomplett.SetActive(false);
            GameManager.Instance.gameplayAktiv = true;
            GameManager.Instance.HinweisUI.SetActive(true);
            GameManager.Instance.HinweisUIText.text = HinweisUITextText[0];
            Debug.Log(dialogZaehler);
            return;

        }

        SoundManager.Instance.PlayWeiterButton();
        


    if (dialogZaehler == 6)
        {
            
            Weiterbutton.SetActive(false);

        }

// damit dialogUI erscheint nach dem Klicken vom Weiter button bei feedback UI
        if (!DialogUiKomplett.activeSelf)

        {

            DialogUiKomplett.SetActive(true);

        }

        //Verhindert doppelte Coroutine
        if (aktuelleSchreibCoroutine != null)
        {

            StopCoroutine(aktuelleSchreibCoroutine);

        }
        SoundManager.Instance.voiceOverPlayer.Stop();

        Debug.Log(dialogZaehler.ToString());
        aktuelleSchreibCoroutine = StartCoroutine(SchreibEffekt(dialoge1[dialogZaehler]));
        DialogSpielen();
        // Damit audio gestoppt wird bei weiter
        dialogZaehler++;




        

      



    }

    public void naechsterDialogWeiter2()
    {
       
        DialogUiKomplett.SetActive(true);
        GameManager.Instance.FeedbackUI.SetActive(false);
        naechsterDialogWeiter();
        
    }




}
