using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompletionScript : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        SceneManager.LoadScene(2);                    //go to the instructions screen
    }
}