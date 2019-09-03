﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTMessageControl : MonoBehaviour
{
    Material btMaterialWait;
    Material btMaterialTurn;
    Material btMaterialEnd;

    MeshRenderer meshRenderer;

    public Texture2D TextureWait;
    public Texture2D TextureTurn;
    public Texture2D TextureEnd;



    // Start is called before the first frame update
    void Start()
    {
        setInitialMat(); //Set Wait as initial material
    }

    // Update is called once per frame
    void Update()
    {
        if (Globals.GlobalVar.OscReportButtonEvent == true)
        {
            Globals.GlobalVar.OscReportButtonEvent = false;

            if (Globals.GlobalVar.OscReportButtonValue == 0) //wait
            {
                GetComponent<MeshRenderer>().material.mainTexture = TextureWait;

            } else if (Globals.GlobalVar.OscReportButtonValue == 1) //turn
            {
                GetComponent<MeshRenderer>().material.mainTexture = TextureTurn;
                Globals.GlobalVar.OscReportButtonValue = 99; //set to invalid option to avoid entering more than once
                if (Globals.GlobalVar.ResetRadiusEvent == false)
                {
                    Globals.GlobalVar.ResetRadius += 1;
                    Globals.GlobalVar.ResetRadiusEvent = true;
                }

            }
            else if (Globals.GlobalVar.OscReportButtonValue == 2) //end
            {
                GetComponent<MeshRenderer>().material.mainTexture = TextureEnd;
            }
        }
        
    }

    void setInitialMat()
    {
        GetComponent<MeshRenderer>().material.mainTexture = TextureWait;
    }





}
