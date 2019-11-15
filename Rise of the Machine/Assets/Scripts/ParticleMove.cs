using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleMove : MonoBehaviour


{
    Rigidbody rb; //declare a reference for the rigidbody
    public float force = 100.0f; //create a force to push the playerObject

    // Start is called before the first frame update
    void Start()
    {
    rb = GetComponent<Rigidbody>(); //get the rigidbody from this playerObject
    }

    // Update is called once per frame
    void Update()
    {

    }

   void OnParticleCollision (GameObject other) // when object enters particle collider
    {
    Vector3 direction  = transform.position - other.transform.position; 
    GetComponent<Rigidbody>().AddForce (direction.normalized * 5); // returns the vector multiplied by five?

    //define direction of object by the intersection of incoming objects current direction with particle direction
    //but problem with how this all is written 

        //rb.AddForce(new Vector3(0, 0, force*2)); //add force up
    }
}
