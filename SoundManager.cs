using UnityEngine;

public class SoundManager : MonoBehaviour
{

    // erzeugt eine globale Referenz 
    public static SoundManager Instance;

    void Awake()
    {

        Instance = this;

    }

    void Start()
    {

        PlayHintergrundMusik();

    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public AudioClip richtigesSortieren;
    public AudioClip falschesSortieren;
    public AudioClip allesSortiert;
    public AudioClip hintergrundMusikSzene2;
    public AudioClip WeiterButton;

    public AudioClip[] dialogVoiceOvers;

    public AudioClip[] hinweisVoiceOvers;
    // 0 Spiegel 
    // 1 Trinkglas 
    // 2 Volles Glas 
    // 3 GameplayHinweis

    public AudioSource derAudioPlayer;
    // 1 von oben (AudioPlayer) ist für sounds

    public AudioSource musikPlayerHintergrund;
// 2 von oben (AudioPlayer) ist für Hintergrundmusik
    public AudioSource voiceOverPlayer;
// 3 von oben (AudioPlayer) ist für DialogVoiceOver

    public AudioSource hinweisVoiceOverPlayer;
// 4 von oben (AudioPlayer) ist für HinweisVoiceOver
    public void PlayRichtigesSortieren()
    {
        derAudioPlayer.PlayOneShot(richtigesSortieren, 4f);
    }

    public void PlayFalschesSortieren()
    {
        derAudioPlayer.PlayOneShot(falschesSortieren);
    }

    public void PlayAllesSortiert()
    {
        derAudioPlayer.PlayOneShot(allesSortiert);
    }

    public void PlayWeiterButton()
    {

        derAudioPlayer.PlayOneShot(WeiterButton);

    }

     public int hinweisVoiceOverTracker = 3;

    public void playHinweisButton ()
    {
        PlayWeiterButton();
        if (hinweisVoiceOverTracker == 0)
        {
        hinweisVoiceOverPlayer.clip = hinweisVoiceOvers[0];
        hinweisVoiceOverPlayer.Play(); 
        }

        if (hinweisVoiceOverTracker == 1)
        {
        hinweisVoiceOverPlayer.clip = hinweisVoiceOvers[1];
        hinweisVoiceOverPlayer.Play(); 
        }

        if (hinweisVoiceOverTracker == 2)
        {
        hinweisVoiceOverPlayer.clip = hinweisVoiceOvers[2];
        hinweisVoiceOverPlayer.Play(); 
        }

        if (hinweisVoiceOverTracker == 3)
        {
        hinweisVoiceOverPlayer.clip = hinweisVoiceOvers[3];
        hinweisVoiceOverPlayer.Play(); 
        }
    }

   

    public void PlayHintergrundMusik()
    {
        musikPlayerHintergrund.clip = hintergrundMusikSzene2;
        musikPlayerHintergrund.loop = true;
        musikPlayerHintergrund.Play();
    }

}
