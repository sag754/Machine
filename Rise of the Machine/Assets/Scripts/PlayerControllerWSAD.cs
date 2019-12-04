using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerWSAD : MonoBehaviour
{
    Rigidbody rb; //declare a reference for the rigidbody

    public GameObject cam;
    public float force = 200.0f; //create a force to push the playerObject
    public float jumpHeight = 50f;
    bool isSmall = false;
    public bool isGrounded;
    public Vector3 large_ball;
    public Vector3 small_ball;
    public bool scale = false;
    public bool stasisGet = false;
    public bool sticky = false;
    public bool stuck = false;
    public float stasisCoolDown;
    private float initialSlowDownTime;
    public float stasis_time_remain;
    public float initialSlowDownDuration = .5f;
    public float coolDownDuration = 10;
    public float stasisDuration = 5;
    public static float gameTimeScale = 1;

    public GameObject sticker;
    private Vector3 collisionPoint;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); //get the rigidbody from this playerObject
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.collider != null)
        {
            if (stuck == true)
            {
                RaycastHit hit;
                Physics.Raycast(gameObject.transform.position, Vector3.down, out hit, 1.5f);
                if (hit.collider == null)
                {
                    gameObject.GetComponent<Rigidbody>().isKinematic = true;
                    sticker.transform.SetParent(other.collider.transform);
                    collisionPoint = other.GetContact(0).point;
                    isGrounded = true;
                } else
                {
                    stuck = false;
                }
            }
        }
        else
        {
            isGrounded = false;
        }
    }

    private void FixedUpdate()
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

        RaycastHit hit;
        Physics.Raycast(gameObject.transform.position, Vector3.down, out hit, 1.5f);
        //Physics.SphereCast(gameObject.transform.position, .6f, Vector3.down, out hit);
        if (stuck == false)
        {
            if (hit.collider != null)
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

        if (isGrounded)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                if (stuck == false)
                {
                    rb.AddForce(Vector3.up * jumpHeight);
                } else
                {
                    stuck = false;
                    isGrounded = false;
                    gameObject.GetComponent<Rigidbody>().isKinematic = false;
                    sticker.transform.SetParent(null);
                    Vector3 awayFromContact = (Vector3.Normalize(gameObject.transform.position - collisionPoint)/6f) + Vector3.up;
                    if (collisionPoint != Vector3.zero)
                    {
                        rb.AddForce(awayFromContact * jumpHeight);
                    }
                }
            }
        }

         if (!Input.anyKey)
        { //if the user hasn't pressed a key
            rb.velocity = rb.velocity * 1.0f; //decrease velocity
        }

    }

    // Update is called once per frame
    void Update()
    {


        if (scale == true)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0)) //if > is pressed
            {
                if (isSmall == false) // checks if isSmall is false
                {
                    transform.localScale = small_ball; //if false, make the ball smaller
                }
                isSmall = true; //changes isSmall to true
            }

            if (Input.GetKeyDown(KeyCode.Mouse1)) // if < is pressed
            {
                if (isSmall == true) //checks if isSmall is true
                {
                    transform.localScale = large_ball; //if true make the ball bigger
                }
                isSmall = false; //changes isSmall to false
            }
        }

        if(sticky == true)
        {
            if(Input.GetKey(KeyCode.Mouse1))
            {
                RaycastHit hit;
                Physics.Raycast(gameObject.transform.position, Vector3.down, out hit, 1.5f);
                if (!hit.collider)
                {
                    stuck = true;
                }
            }

            else
            {
                stuck = false;
                gameObject.GetComponent<Rigidbody>().isKinematic = false;
                sticker.transform.SetParent(null);
            }
        }



        if(stasisGet == true)
        //activates stasis ability
        //if (stasisGet == true && Input.GetKeyDown(KeyCode.E) && stasis_time_remain <= 0 && stasisCoolDown <= 0)
        if (Input.GetKeyDown(KeyCode.E) && stasis_time_remain <= 0 && stasisCoolDown <= 0)
        {
                stasisCoolDown = coolDownDuration;
                initialSlowDownTime = initialSlowDownDuration;
            }

            //stasis power
        if (initialSlowDownTime > 0)
        {
            initialSlowDownTime = Mathf.Max(0, initialSlowDownTime - Time.unscaledDeltaTime);
            gameTimeScale = initialSlowDownTime / initialSlowDownDuration;

            if (initialSlowDownTime <= 0)
            {
                stasis_time_remain = stasisDuration;
            }
        }

        //the duration of how long the stasis lasts
        if (stasis_time_remain > 0)
        {
            stasis_time_remain = Mathf.Max(0, stasis_time_remain - Time.unscaledDeltaTime);

            if (stasis_time_remain <= 0)
            {
                gameTimeScale = 1;
            }
        }

        //the duration of how long the cool down lasts
        if (stasisCoolDown > 0)
        {
            stasisCoolDown = Mathf.Max(0, stasisCoolDown - Time.unscaledDeltaTime);
        }
    }
    
}
