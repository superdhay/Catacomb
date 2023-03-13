using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueShiny : MonoBehaviour
{
    private GameObject Canvas;
    public GameObject PhraseShiny;
    

    public bool FlagOneShot;
    public bool FlagTexteNarration;

    public string LeMessage;

    public int Compteur;

    // Start is called before the first frame update
    void Start()
    {
        Canvas = GameObject.Find("UI");
        Compteur = 1;
        PhraseShiny.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (FlagTexteNarration == true)
        {
            Canvas.GetComponent<DialogueManager>().ZoneDeTexte.color = Color.white;
        }
        else
            Canvas.GetComponent<DialogueManager>().ZoneDeTexte.color = new Color(1f, 0.99f, 0.83f, 1f);

        if (FlagOneShot == false)
        {
            Canvas.GetComponent<DialogueManager>().ActivationDialogue = true;
            Canvas.GetComponent<DialogueManager>().LeTexte = LeMessage;
            PhraseShiny.SetActive(true);
        }
        
        if (FlagOneShot == true)
        {
            if(Compteur <= 1)
            {
                Canvas.GetComponent<DialogueManager>().ActivationDialogue = true;
                Canvas.GetComponent<DialogueManager>().LeTexte = LeMessage;
                PhraseShiny.SetActive(true);
                
            }
            if (Compteur > 1)
            {
                Canvas.GetComponent<DialogueManager>().LeTexte = "";
                Canvas.GetComponent<DialogueManager>().ActivationDialogue = false;
                PhraseShiny.SetActive(false);
            }
        }
        Compteur++;
    }
    private void OnTriggerExit(Collider other)
    {
        Canvas.GetComponent<DialogueManager>().LeTexte = "";
        Canvas.GetComponent<DialogueManager>().ActivationDialogue = false;
        PhraseShiny.SetActive(false);
    }


}
