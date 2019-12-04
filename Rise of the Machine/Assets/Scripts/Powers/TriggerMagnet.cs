using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMagnet : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<PlayerControllerWSAD>().sticky = true;
        Destroy(gameObject);
    }
}
