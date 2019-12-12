using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingScript : MonoBehaviour
{

    private float LevelLoadDelay = 5;

    private void Update()
    {
        if (Input.anyKey)                  //if the player hits the spacebar
        {
            Invoke("LoadNextLevel", LevelLoadDelay);                    //go to the instructions screen
        }
    }

    private void LoadNextLevel()
    {
        SceneManager.LoadScene(0);
    }
}