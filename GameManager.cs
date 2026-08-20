using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class GameManager : MonoBehaviour
{


    // Wichtig: BadgeGlasFliegt muss zugewiesen werden bei GameObject + am anfang deaktiviert UND DIALOGMANAGER Und FeedbackUIText
    public GameObject BadgeGlasFliegt;

    //DialogManager in GameManager Script ziehen
    public DialogManager dialogManager;


    // Damit man nicht während der dialoge stuff rumziehen kann
    public bool gameplayAktiv = false;


    public static GameManager Instance;

    //FeedbackIdee: Gebrachte zeit angeben und je nachdem einen anderen feedback satz
    // Anzahl falscher sortierungen angeben
    public float gameplayZeit; // das ist die zeit in sekunden genau
    public float gamePlayZeitGerundet;

    public float anzahlFalscherSortierungen;


    public GameObject FeedbackUI;
    public TextMeshProUGUI FeedbackUISekunden;
    public TextMeshProUGUI FeedbackUISekundenVariable;
    public TextMeshProUGUI FeedbackUIAnzahlFalscherSort;
    public TextMeshProUGUI HinweisUIText;
    public GameObject HinweisUI;

    public Animator ShellyREDE;

    public GameObject Shelly;



    IEnumerator wartenNachGameplay()
    {

        yield return new WaitForSeconds(2.2f);
        // dialogManager.DialogUiKomplett.SetActive(true);
        FeedbackUI.SetActive(true);
        FeedbackUISekundenVariable.text = gamePlayZeitGerundet.ToString() + "s.";
        FeedbackUIAnzahlFalscherSort.text = anzahlFalscherSortierungen.ToString();



        // startet Co Routine UND speichert sie

    }

    void Update()
    {
        //Time.deltaTime misst wie viel zeit (sekunden) nach dem lezzten frame vergengen ist (gut weil das unterschiedlich ist je nach fps)
        if (gameplayAktiv)
        {
            gameplayZeit += Time.deltaTime;
            gamePlayZeitGerundet = Mathf.Round(gameplayZeit);
        }

        if (anzahlRichtigerSortierungen == 10) {

            gameplayAktiv = false;
        }

   // damit gameplay auch beim 2. diaog aus ist
    //if (DialogManager.)

    }


    void Awake()
    {

        Instance = this;

    }


    public SpriteRenderer BildAnzeige;

    public Slider FortschrittsBalken;
    public Sprite strand1;
    public Sprite flasche1;
    public Image hintergrundImage;


    public int anzahlRichtigerSortierungen = 0;




    public void starteAnimationBadge()
    {
        if (anzahlRichtigerSortierungen == 10)
        {

            BadgeGlasFliegt.SetActive(true);

            SoundManager.Instance.PlayAllesSortiert();

            Debug.Log("GameplayZeit=" + gamePlayZeitGerundet);

            Debug.Log("AnzahlFalscherSortrierungen=" + anzahlFalscherSortierungen);

            StartCoroutine(wartenNachGameplay());

        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
}//Lege den Müll in den Altglass Container: Lass deinen Zeiger über einem Müllobjekt schweben, drücke die linke Maustaste, halte diese gedrückt, und bewege deine Maus. Wenn der Müll über dem Container schwebt, lasse die linke Maustaste los