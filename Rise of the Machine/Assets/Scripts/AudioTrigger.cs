using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTrigger : MonoBehaviour
 {
     public AudioClip rolltest3;    // Add audio Here;
     // configures AudioSource Component; 
     // ensure you add AudioSource to playSound area;
     void Start ()   
     {
         GetComponent<AudioSource> ().playOnAwake = false;
         GetComponent<AudioSource> ().clip = rolltest3;
     }        
 
     void OnCollisionEnter ()  //Plays Sound Whenever collision detected
     {
         GetComponent<AudioSource> ().Play ();
     }
          // Make sure that zone has a collider, box, mesh.. etc..,
          // Make sure to turn "off" collider trigger for your deathzone Area;
          // Make sure That anything that collides into deathzone, is rigidbody;

          // use col.gameObject.CompareTag("Grounded") to deactivate sound when ball is in the air?
 }
