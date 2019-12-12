using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerStasisPower : MonoBehaviour
{
    public GameObject UIStasisInfo;

    private void Start()
    {
        UIStasisInfo.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        UIStasisInfo.SetActive(true);
        other.gameObject.GetComponent<PlayerControllerWSAD>().stasisGet = true;
        GetComponent<Collider>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            UIStasisInfo.SetActive(false);
        }
    }
}
