using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAudio : MonoBehaviour
{
    public AudioSource audio; //create a field for the AudioSource "audio"
    bool hasPlayed = false;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>(); //get the AudioSource component from this gameObject
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //if something hits this trigger
    private void OnTriggerEnter(Collider other)
    {
        
        if (!hasPlayed) {
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            if (other.gameObject.GetComponent<Rigidbody>() == null) {
                return;
            }

            audio.Play(); //play the audio
            hasPlayed = true;
        }
    }
}