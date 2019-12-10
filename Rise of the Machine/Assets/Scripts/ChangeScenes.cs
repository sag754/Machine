using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScenes : MonoBehaviour
{
    public string SceneName; 
    public void OnTriggerEnter( Collider other)
    {
        SceneSwitch();
        Debug.Log ("go to ending");
               
    }
    public void SceneSwitch () { // got to scene 2
        SceneManager.LoadScene (SceneName);
        }
}
