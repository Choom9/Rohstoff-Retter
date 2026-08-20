using System.Collections;
using System.Globalization;
using UnityEditor;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    
    // Generelle Info: Auf Müllobjekte muss BoxCollider2d, auf Mülltone Boxcollider2d UND RigidBody2d
    // Generelle Info: GameManager Script muss jedem Müllobjekt im Inspector zugeordnet werden // OBSOLET DURCH GameManager.Instance
    //Wichtig: Der Mülltonne tag Mülleimer geben

    

    string[] hinweisSpecialMüll = new string[]
    {
        // 0, Hinweis für Tag TrinkGlas
        "Stimmt, das ist Glas! Trinkgläser gehören aber nicht ins Altglas, weil sie viel mehr Hitze zum Schmelzen brauchen. Damit der Rest gut recycelt werden kann, werfen wir dieses Glas in den Restmüll.",

        // 1, Hinweis für Spiegel
        "Der Spiegel besteht zwar aus Glas, aber aus beschichtetem Flachglas. Weil das den Recyclingprozess stört, werden kleine Scherben in den Restmüll geworfen und große Spiegel zum Wertstoffhof gebracht.",

        // 2, Hinweis für volles Glas 
        "Richtig erkannt, dieser Behälter sollte recycelt werden. Vorher muss der Inhalt aber noch entsorgt werden, denn nur leere Gläser ohne Deckel dürfen in den Altglas Container.",



    };

    public bool weissGlas;
    public bool braunGlas;
    public bool grünGlass;
//  Je nach Müll muss manuell im Inspector richtiger Glas Typ zugeordnet werden
// Nötig damit die 3 Container richtigen Glastyp erkennen

    public bool richtigerMüll = true;




    public bool istMüllÜberEimer = false;

    public MüllTonne müllTonnenScript;

    public Vector3 letztePosition;

    void OnMouseDown()
    {
        letztePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        GameManager.Instance.HinweisUI.SetActive(false);
        SoundManager.Instance.hinweisVoiceOverPlayer.Stop();
    }
    void OnMouseDrag()
    {
        // das if damit man während der dialoge nicht spielen kann
        if (GameManager.Instance.gameplayAktiv == true)
        {
            Vector3 richtigeWeltK = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(richtigeWeltK.x, richtigeWeltK.y, 0);
        }
    }


bool istWeisserContainer = false;
bool istBraunerContainer = false;
bool istGrünerContainer = false;

bool containerMüllMatch = false; // Zustand wenn Müll und Container matchen
    void OnTriggerEnter2D(Collider2D other)
    {
        // wichtig: Tag Mülleimer muss den Tonnen zugeordnet sein
        if (other.CompareTag("Mülleimer"))
        {
            istMüllÜberEimer = true;
            Debug.Log("Müll ist über Mülleimer");
            müllTonnenScript = other.GetComponent<MüllTonne>();
            // das script jeder einzelnen Tonne holen
            
        if (müllTonnenScript.grünerContainer && grünGlass || müllTonnenScript.braunerContainer  && braunGlas || müllTonnenScript.weisserContainer  && weissGlas)
        {
            containerMüllMatch = true;
        }
        else
        {
            containerMüllMatch = false;
        }

        }
    }

void OnTriggerStay2D(Collider2D other)
    {
         // wichtig: Tag Mülleimer muss den Tonnen zugeordnet sein
        if (other.CompareTag("Mülleimer"))
        {
            istMüllÜberEimer = true;
            müllTonnenScript = other.GetComponent<MüllTonne>();
            // das script jeder einzelnen Tonne holen
            
        if (müllTonnenScript.grünerContainer && grünGlass || müllTonnenScript.braunerContainer  && braunGlas || müllTonnenScript.weisserContainer  && weissGlas)
        {
            containerMüllMatch = true;
        }
        else
        {
            containerMüllMatch = false;
        }

        }

    }

// aus dem other (der Müttonne) die Art der Mülltonne herausfinden 

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Mülleimer"))
        {
            istMüllÜberEimer = false;
            containerMüllMatch = false;
        }
    }


    // Hier HauptPrüfLogik
    void OnMouseUp()
    {

        // damit sachen zurück telepoertiert weden wenn man sie außerhalb des sichtbaren bereichs platziert
        if (transform.position.x <= -8.8f || transform.position.x >= 8.8f || transform.position.y <= -4.8f || transform.position.y >= 4.8f ) {
            transform.position = new Vector3(letztePosition.x, letztePosition.y, 0);
        }




        //wenn richtig sortiert
        if (istMüllÜberEimer && richtigerMüll && containerMüllMatch)
        {
            gameObject.SetActive(false);
            müllTonnenScript.ZeigeGrünEffekt();
            GameManager.Instance.anzahlRichtigerSortierungen++;
            GameManager.Instance.FortschrittsBalken.value = GameManager.Instance.anzahlRichtigerSortierungen;
            SoundManager.Instance.PlayRichtigesSortieren();
            GameManager.Instance.starteAnimationBadge();
        }

        else if (istMüllÜberEimer && CompareTag("TrinkGlas"))
        {

            müllTonnenScript.ZeigeRotEffekt();
            SoundManager.Instance.PlayFalschesSortieren();
            SoundManager.Instance.hinweisVoiceOverTracker = 1;
            transform.position = new Vector3(letztePosition.x, letztePosition.y, 0);
            GameManager.Instance.anzahlFalscherSortierungen++;
            GameManager.Instance.HinweisUI.SetActive(true);
            GameManager.Instance.HinweisUIText.text = hinweisSpecialMüll[0];

        }


        else if (istMüllÜberEimer && CompareTag("Spiegel")) {

            müllTonnenScript.ZeigeRotEffekt();
            SoundManager.Instance.PlayFalschesSortieren();
            SoundManager.Instance.hinweisVoiceOverTracker = 0;
            transform.position = new Vector3(letztePosition.x, letztePosition.y, 0);
            GameManager.Instance.anzahlFalscherSortierungen++;
            GameManager.Instance.HinweisUI.SetActive(true);
            GameManager.Instance.HinweisUIText.text = hinweisSpecialMüll[1];

        }

         else if (istMüllÜberEimer && CompareTag("GurkenGlas")) {

            müllTonnenScript.ZeigeRotEffekt();
            SoundManager.Instance.PlayFalschesSortieren();
            SoundManager.Instance.hinweisVoiceOverTracker = 2;
            transform.position = new Vector3(letztePosition.x, letztePosition.y, 0);
            GameManager.Instance.anzahlFalscherSortierungen++;
            GameManager.Instance.HinweisUI.SetActive(true);
            GameManager.Instance.HinweisUIText.text = hinweisSpecialMüll[2];

        }
        



        //Wenn falsch sortiert
        else if (istMüllÜberEimer && !containerMüllMatch)
        {
            müllTonnenScript.ZeigeRotEffekt();
            SoundManager.Instance.PlayFalschesSortieren();
            transform.position = new Vector3(letztePosition.x, letztePosition.y, 0);
            GameManager.Instance.anzahlFalscherSortierungen++;

        }


    }



}
