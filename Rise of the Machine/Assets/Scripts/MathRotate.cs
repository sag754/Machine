using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathRotate : MonoBehaviour
{
    
    public float timer = 0; //track time game has been running since startup
    public float freq = 1;  //wave length
    public float amp = 5;   //wave amplitude

void Update()
    {
    if (timer<30){
        timer += Time.deltaTime;
        } //add time to timer on every frame
    
    if (timer>100){
        timer -= Time.deltaTime;

        } //add time to timer on every frame
    transform.position = new Vector3( //apply circular movement to object 
                    Mathf.Cos(timer * freq) * amp,  //use cos for the x-axis
                    Mathf.Sin(timer * freq) * amp,  //use sin for the y-axis
                    0);
    
    
    }
}