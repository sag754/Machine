using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingScript : MonoBehaviour
{

    private void Update()
    {
        if (Input.anyKey)                  //if the player hits the spacebar
        {
            SceneManager.LoadScene(0);                    //go to the instructions screen
        }
    }
}