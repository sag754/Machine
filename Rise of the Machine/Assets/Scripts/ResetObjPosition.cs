using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetObjPosition : MonoBehaviour
{
    public new Vector3 startPos; //declare position to respawn object
    public int spawnTime = 2; // declare delay except its useless
    public Collider holder;

    // Start is called before the first frame update
    void Start()
    {
  
    Invoke(nameof(p),spawnTime); // introduces function to allow to call for debug
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //if something hits this trigger

    
    public void OnTriggerEnter(Collider ObjectTriggerEnter)
    {
    holder = ObjectTriggerEnter; // extra step for Invoke to use. Invoke cannot invoke a function with a parameter
   

    Invoke("Spawn", spawnTime); // delay spawn action 
    }
    void Spawn ()
    {
        GameObject otherObj = holder.gameObject; //get other game object

        Rigidbody otherRb = otherObj.GetComponent<Rigidbody>(); //get object's rigidBody

        otherRb.MovePosition(startPos); //use MovePosition to return object to start position
        otherRb.velocity = Vector3.zero; //resend velocity to 0,0,0
    }

    void p(){
        print("function is running"); // print to console to verify when Invoke is running
    }
}
