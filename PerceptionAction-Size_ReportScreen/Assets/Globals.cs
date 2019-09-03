using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globals : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public class GlobalVar
    {
        public static int dialRight = 0;
        public static int dialLeft = 0;
        public static int dialClick = 0;

        public static bool dialShowHideUpdate = false;
        public static int dialShowHide = 1; //1 = Show

        public static bool dialSizeUpdate = false;
        public static int dialSizeRef = 1; //35 mm
        //Dial ref:    1  2  3  4  5  6  7  8  9  0  
        //Dial sizes: 35,40,45,50,55,60,65,70,75,80

        public static string buttonPress = "";
        public static string prevButtonPress = "";

        public static string oscMessage = "";
        public static string prevOscMessage = "";
        public static bool OscSendEvent = false;

        public static string dialSync = "";
        public static bool OscSendSyncEvent = false;

        public static string inputDialSync = "";
        public static bool OscReceiveSyncEvent = false;

        public static int neopixelMessage = 0;
        public static bool OscSendNeopixelEvent = false;
        public static int NeopixelEventCount = 0;

        public static float prev_radius = 0f;
        public static float radiusSyncValue = 0f;
        public static bool OscSendRadiusSyncEvent = false;

    }
}