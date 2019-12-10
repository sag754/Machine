using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextChange : MonoBehaviour
{

// Setup text lines
public GameObject Intro1;
public GameObject Intro2; 


public void OnClickIntro() 
    // on click, changetext
    {
        Intro1.SetActive(false);
        Intro2.SetActive(true);

    
    
    }
}
