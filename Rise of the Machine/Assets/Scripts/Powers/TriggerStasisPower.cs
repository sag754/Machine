using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerStasisPower : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        other.gameObject.GetComponent<PlayerControllerWSAD>().stasisGet = true;
        Destroy(gameObject);
    }
}
