using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMagnet : MonoBehaviour
{

    public GameObject UIMagnetInfo;

    private void Start()
    {
        UIMagnetInfo.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        UIMagnetInfo.SetActive(true);
        other.gameObject.GetComponent<PlayerControllerWSAD>().sticky = true;
        GetComponent<Collider>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            UIMagnetInfo.SetActive(false);
        }
    }
}
