using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathNoise : MonoBehaviour
{
    //this movement is "art" not function
    public float timer = 0; //track time game has been running since startup
    public float amp = 1;   //wave amplitude
void Update()
    {
    timer += Time.deltaTime; //add time to timer on every frame
    
    
    transform.position = new Vector3( //use Perlin Noise to move sphere vertically
                    transform.position.x + Time.deltaTime, // move on x
                    (Mathf.PerlinNoise(transform.position.x, 0) * 3 - 1) * amp, //use noise on y
                    0); // don't move z
     
    }
}