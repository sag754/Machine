using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScale : MonoBehaviour
{

    public GameObject UIScaleInfo;

    private void Start()
    {
        UIScaleInfo.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        UIScaleInfo.SetActive(true);
        other.gameObject.GetComponent<PlayerControllerWSAD>().scale=true;
        GetComponent<Collider>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            UIScaleInfo.SetActive(false);
        }
    }
}
