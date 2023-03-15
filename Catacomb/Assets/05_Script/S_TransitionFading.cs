using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_TransitionFading : MonoBehaviour
{

    public GameObject FadeIn, FadeOut, FadeInOut;

    float Timer;

    private void Awake()
    {
        FadeIn.SetActive(false);
        FadeOut.SetActive(true);
        FadeInOut.SetActive(false);
        Timer = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (Timer < 3) Timer = Timer + Time.deltaTime;
        if (Timer >= 2.5f) FadeOut.SetActive(false);

        if (GameManager.Flag_Dead) FadeIn.SetActive(true);
        if (GameManager.Flag_Void)
        {
            FadeInOut.SetActive(true);
            FadeInOut.GetComponent<Animator>().SetTrigger("Fade");
        }

    }
}
