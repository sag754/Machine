using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSpringJump : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<PlayerControllerWSAD>().jumpHeight=1600;
        Destroy(gameObject);
    }

}
