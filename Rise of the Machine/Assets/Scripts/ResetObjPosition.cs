using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetObjPosition : MonoBehaviour
{
    public new Vector3 startPos; //declare position to respawn object
    public float spawnTime = 2.5f; // declare delay except its useless
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //if something hits this trigger

    
    public void OnTriggerEnter(Collider other)
    {
    //Invoke("Spawn", spawnTime); // delay spawn action but actually doesnt work at this time

    Spawn(other);
    
    }
    void Spawn (Collider other)
    {
        GameObject otherObj = other.gameObject; //get other game object

        Rigidbody otherRb = otherObj.GetComponent<Rigidbody>(); //get object's rigidBody

        otherRb.MovePosition(startPos); //use MovePosition to return object to start position
        otherRb.velocity = Vector3.zero; //resend velocity to 0,0,0
    }
}
