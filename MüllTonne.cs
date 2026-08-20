using System.Collections;
using UnityEngine;

public class MüllTonne : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // Generelle Info: Auf Müllobjekte muss BoxCollider2d, auf Mülltone Boxcollider2d UND RigidBody2d
    // je nach Container den richtigen Tag zuordnen: weisserContainer, braunerContainer, grünerContainer
   
    
    
    public DragAndDrop momentanerMüllScript;


    public bool grünerContainer = false;

    public bool weisserContainer = false;

    public bool braunerContainer = false;
    // public hier wichtig, weil sonst ist ein Zugriff von außen nicht möglich
    // die Werte müssen im Inspector bei jeder Tonne entsprechend angepasst werden
    // individueller Wert wird dann über collider other ans müllobjekt geschickt

    public IEnumerator RotEffekt()
    {
        GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0f, 0.9f);

        yield return new WaitForSeconds(1f);

        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
    }

    public void ZeigeRotEffekt()
    {
        StartCoroutine(RotEffekt());
    }

    public IEnumerator GrünEffekt()
    {
        GetComponent<SpriteRenderer>().color = new Color(0f, 1f, 0f, 0.9f);

        yield return new WaitForSeconds(1f);

        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
    }

    public void ZeigeGrünEffekt()
    {
        StartCoroutine(GrünEffekt());
    }



    void OnTriggerEnter2D(Collider2D other)
    {

        momentanerMüllScript = other.GetComponent<DragAndDrop>();

    }





}
