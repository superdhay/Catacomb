using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public string LeTexte;

    public Text ZoneDeTexte;

    public bool ActivationDialogue;
    public bool FlagText;

    public GameObject PanelDeTexte;

    // Start is called before the first frame update
    void Start()
    {
        PanelDeTexte = GameObject.Find("PanelDialogue");
        ActivationDialogue = false;
        FlagText = false;
        PanelDeTexte.SetActive(false);
        ZoneDeTexte.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (ActivationDialogue == true)
        {
            if (FlagText == false)
            {
                PanelDeTexte.SetActive(true); // Active le canvas de dialogue
                StartCoroutine(AfficheTexte());
                FlagText = true;
            }
        }

        if (ActivationDialogue == false)
        {
            PanelDeTexte.SetActive(false); // Desactive le canvas de dialogue
            FlagText = false;
            ZoneDeTexte.text = "";
            StopAllCoroutines();
        }
    }
    IEnumerator AfficheTexte()
    {
        foreach (char c in LeTexte.ToCharArray())   // pour chaque charactère de la "string" LeTexte
        {
            ZoneDeTexte.text = ZoneDeTexte.text + c;      // afficher un charactère de la chaine de char
            yield return new WaitForSeconds(0.05f);  // faire une pause de 0.05 seconde
        }
    }
}
