using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OSCsharp.Data;

namespace UniOSC
{

    public class OscReceiveReportBtState : UniOSCEventTarget
    {
        public override void OnOSCMessageReceived(UniOSCEventArgs args)
        {
                OscMessage msg = (OscMessage)args.Packet;
                Globals.GlobalVar.OscReportButtonValue = (int)msg.Data[0];
                Globals.GlobalVar.OscReportButtonEvent = true;
        }


    }
}