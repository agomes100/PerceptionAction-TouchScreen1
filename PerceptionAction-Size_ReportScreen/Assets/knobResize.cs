using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knobResize : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    	if (Globals.GlobalVar.dialSizeUpdate == true)
        {
            Globals.GlobalVar.dialSizeUpdate = false;
            Resize(Globals.GlobalVar.dialSizeRef);
        }
        
    }

    void Resize(int sizeRef){
    	float nSize = 0f;
    	float standard_height = 0.508f;
    	switch (sizeRef)
      {
          case 1:
              nSize = 35f/59f;
              Debug.Log("knobResize::dialSizeRef=1");
              break;
          case 2:
              nSize = 40f/59f;
              Debug.Log("knobResize::dialSizeRef=2");
              break;
          case 3:
              nSize = 45f/59f;
              Debug.Log("knobResize::dialSizeRef=3");
              break;
          case 4:
              nSize = 50f/59f;
              Debug.Log("knobResize::dialSizeRef=4");
              break;
          case 5:
              nSize = 55f/59f;
              Debug.Log("knobResize::dialSizeRef=5");
              break;
          case 6:
              nSize = 60f/59f;
              Debug.Log("knobResize::dialSizeRef=6");
              break;
          case 7:
              nSize = 65f/59f;
              Debug.Log("knobResize::dialSizeRef=7");
              break;
          case 8:
              nSize = 70f/59f;
              Debug.Log("knobResize::dialSizeRef=8");
              break;
          case 9:
              nSize = 75f/59f;
              Debug.Log("knobResize::dialSizeRef=9");
              break;
          case 0:
              nSize = 80f/59f;
              Debug.Log("knobResize::dialSizeRef=0");
              break;
          default:
              nSize = 35f/59f;
              Debug.Log("knobResize::dialSizeRef=default !!! 1");
              break;
      }
      Debug.Log("knobResize::Calculated Size: "+nSize);
      transform.localScale = new Vector3(nSize, standard_height, nSize);
    }
}
