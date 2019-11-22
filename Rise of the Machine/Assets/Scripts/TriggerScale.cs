using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScale : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<PlayerControllerWSAD>().scale=true;
        Destroy(gameObject);
    }
}
