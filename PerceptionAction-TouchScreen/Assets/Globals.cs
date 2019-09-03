using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globals : MonoBehaviour
{

    public class GlobalVar
    {
        public static float prev_radius = 0f;
        public static float radiusSyncValue = 0f;
        public static bool OscSendRadiusSyncEvent = false;

        public static bool OscSendEndTrialValue = false;
        public static bool OscSendEndTrialEvent = false;

        public static bool newRadiusInformed = false;

        public static int OscReportButtonValue = 0; //0-Wait to begin next trial | 1-Turn Around | 2-Press to End
        public static bool OscReportButtonEvent = false;

        public static char dialLeft = ' ';
        public static char dialRight = ' ';

        public static int ResetRadius = 0;
        public static bool ResetRadiusEvent = false;

    }
}