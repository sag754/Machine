﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerWSAD : MonoBehaviour
{
    Rigidbody rb; //declare a reference for the rigidbody

    public GameObject camera;
    public float force = 100.0f; //create a force to push the playerObject
    public float jump = 10000f;
    bool isSmall = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); //get the rigidbody from this playerObject
    }

    // Update is called once per frame
    void Update()
    {
        bool hasInput = false; //create a local variable to track whether the user has inputed something

        if (Input.GetKey(KeyCode.W))
        { //if the W is pressed
            //rb.AddForce(new Vector3(0, 0, force)); //add force up
            Vector3 cameraforward = camera.transform.forward;
            cameraforward.y = 0;
            cameraforward = Vector3.Normalize(cameraforward);
            rb.AddForce(cameraforward * force);
            hasInput = true; //the user has pressed a key
        }

        if (Input.GetKey(KeyCode.S))
        { //if the S is pressed
            //rb.AddForce(new Vector3(0, 0, -force)); //add force down
            Vector3 cameraforward = camera.transform.forward;
            cameraforward.y = 0;
            cameraforward = Vector3.Normalize(cameraforward);
            rb.AddForce(cameraforward * -force);
            hasInput = true; //the user has pressed a key
        }

        if (Input.GetKey(KeyCode.A))
        { //if the A is pressed
            //rb.AddForce(new Vector3(-force, 0, 0)); //add force left
            Vector3 cameraright = camera.transform.right;
            cameraright.y = 0;
            cameraright = Vector3.Normalize(cameraright);
            rb.AddForce(cameraright * -force);
            hasInput = true; //the user has pressed a key
        }

        if (Input.GetKey(KeyCode.D))
        {//if the D is pressed
         //rb.AddForce(new Vector3(force, 0, 0)); //add force right
            Vector3 cameraright = camera.transform.right;
            cameraright.y = 0;
            cameraright = Vector3.Normalize(cameraright);
            rb.AddForce(cameraright * force);
            hasInput = true; //the user has pressed a key
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector3(0, force, 0));
            hasInput = true;
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

    }
}
