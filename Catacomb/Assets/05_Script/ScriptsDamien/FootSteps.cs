using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSteps : MonoBehaviour
{
    public AudioClip[] soundClips;

    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Step()
    {
        AudioClip soundClip = soundClips[Random.Range(0, soundClips.Length)];
        audioSource.PlayOneShot(soundClip);
        Debug.Log("Step!");
    }
    
}
