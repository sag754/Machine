using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator_Y : MonoBehaviour
{

    public float y_speed = 1.0f;  //applies default speed and makes public for adjusting in editor/inspector

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, y_speed, 0 * Time.deltaTime * PlayerControllerWSAD.gameTimeScale);  //tranform a gameobject's rotation based off the Y-axis

    }
}
