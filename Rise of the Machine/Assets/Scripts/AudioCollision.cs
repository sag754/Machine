using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCollision : MonoBehaviour
{
    public AudioClip audioClip; //create a field for the AudioSource "audio"
    bool hasPlayed = false;
    

    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        
    }

    //if something hits this trigger
    private void OnTriggerEnter(Collider other)
    {
        
        if (!hasPlayed) {
           

            AudioSource audioYeah = GetComponent<AudioSource>();
            audioYeah.clip = audioClip;
            audioYeah.Play();
            hasPlayed = true;
        }
    }
}
