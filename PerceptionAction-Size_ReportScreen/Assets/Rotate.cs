using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

    float smooth = 100.0f;
    float tiltAngle = 0.0f;
    private float step = 9.8f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Globals.GlobalVar.dialLeft == 1)
        {
            Globals.GlobalVar.dialLeft = 0;
            tiltAngle = tiltAngle + step;
            RotateObject(tiltAngle);
        }
        else if (Globals.GlobalVar.dialRight == 1)
        {
            Globals.GlobalVar.dialRight = 0;
            tiltAngle = tiltAngle - step;
            RotateObject(tiltAngle);
        }

    }

    void RotateObject (float tiltAroundZ)
    {
        // Smoothly tilts a transform towards a target rotation tiltAroundZ.

        // Rotate the quad by converting the angles into a quaternion.
        Quaternion target = Quaternion.Euler(0, tiltAroundZ, 0);

        // Dampen towards the target rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);

        //transform.Rotate(0, 0, tiltAngle, Space.Self);
       // Debug.Log("tilt angle: " + tiltAngle);
    }
}
