using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputListener : MonoBehaviour
{
    public bool keyboard_active = true;

    // Update is called once per frame
    void Update()
    {
      if (keyboard_active)
        {
            if (Input.GetKey("left"))
            {
                Globals.GlobalVar.dialLeft = 'L';
                Debug.Log("InputListener::Update:Left rotation sensed.");
            }
            else if (Input.GetKey("right"))
            {
                Globals.GlobalVar.dialRight = 'R';
                Debug.Log("InputListener::Update:Right rotation sensed.");
            }
        }    
    }
}
