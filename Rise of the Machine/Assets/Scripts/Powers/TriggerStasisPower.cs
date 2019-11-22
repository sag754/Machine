using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerStasisPower : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<PlayerControllerWSAD>().stasisGet = true;
        Destroy(gameObject);
    }
}
