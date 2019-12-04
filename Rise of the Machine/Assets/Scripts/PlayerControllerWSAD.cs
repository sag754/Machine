using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerWSAD : MonoBehaviour
{
    Rigidbody rb; //declare a reference for the rigidbody

    public GameObject cam;
    public float force = 100.0f; //create a force to push the playerObject
    public float jumpHeight = 50f;
    bool isSmall = false;
    public bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); //get the rigidbody from this playerObject
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.collider != null)
        {
            isGrounded = true;
        }

        else
        {
            isGrounded = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        bool hasInput = false; //create a local variable to track whether the user has inputed something

        if (Input.GetKey(KeyCode.W))
        { //if the W is pressed
            Vector3 cameraforward = cam.transform.forward;
            cameraforward.y = 0;
            cameraforward = Vector3.Normalize(cameraforward);
            rb.AddForce(cameraforward * force);
            hasInput = true; //the user has pressed a key
        }

        if (Input.GetKey(KeyCode.S))
        { //if the S is pressed
            Vector3 cameraforward = cam.transform.forward;
            cameraforward.y = 0;
            cameraforward = Vector3.Normalize(cameraforward);
            rb.AddForce(cameraforward * -force);
            hasInput = true; //the user has pressed a key
        }

        if (Input.GetKey(KeyCode.A))
        { //if the A is pressed
            Vector3 cameraright = cam.transform.right;
            cameraright.y = 0;
            cameraright = Vector3.Normalize(cameraright);
            rb.AddForce(cameraright * -force);
            hasInput = true; //the user has pressed a key
        }

        if (Input.GetKey(KeyCode.D))
        {//if the D is pressed
            Vector3 cameraright = cam.transform.right;
            cameraright.y = 0;
            cameraright = Vector3.Normalize(cameraright);
            rb.AddForce(cameraright * force);
            hasInput = true; //the user has pressed a key
        }

        if(isGrounded)
        {
           if(Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(Vector3.up * jumpHeight);
            }
        }

        if (Input.GetKeyDown(KeyCode.Period)) //if > is pressed
        {
            if (isSmall == false) // checks if isSmall is false
            {
                transform.localScale -= new Vector3(2, 2, 2); //if false, make the ball smaller
            }
            isSmall = true; //changes isSmall to true
        }

        if (Input.GetKeyDown(KeyCode.Comma)) // if < is pressed
        {
            if (isSmall == true) //checks if isSmall is true
            {
                transform.localScale += new Vector3(2, 2, 2); //if truem make the ball bigger
            }
            isSmall = false; //changes isSmall to false
        }

        if (!Input.anyKey)
        { //if the user hasn't pressed a key
            rb.velocity = rb.velocity * 1.0f; //decrease velocity
        }

        RaycastHit hit;
        Physics.Raycast(gameObject.transform.position, Vector3.down, out hit, 1.5f);
        //Physics.SphereCast(gameObject.transform.position, .6f, Vector3.down, out hit);

        if(hit.collider != null)
        {
            isGrounded = true;
            if (hit.collider.gameObject.CompareTag("Conveyor"))
            {
                rb.AddForce(hit.collider.gameObject.transform.forward);
            }
        }
        else
        {
            isGrounded = false;
        }
    }
}
