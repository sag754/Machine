using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSpringJump : MonoBehaviour
{

    public GameObject UIJumpInfo;

    private void Start()
    {
        UIJumpInfo.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        UIJumpInfo.SetActive(true);
        other.gameObject.GetComponent<PlayerControllerWSAD>().jumpHeight=1600;
        GetComponent<Collider>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;
        
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            UIJumpInfo.SetActive(false);
        }
    }

}
