﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System;
using OSCsharp.Data;

namespace UniOSC
{

    /// <summary>
    /// Dispatcher button that forces a OSCConnection to send a OSC Message.
    /// Two separate states: Down and Up 
    /// </summary>
    [AddComponentMenu("UniOSC/EventDispatcherButton")]
    [ExecuteInEditMode]
    public class OscSendDialInput : UniOSCEventDispatcher
    {
        public override void Awake()
        {
            base.Awake();
        }

        public override void OnEnable()
        {
            base.OnEnable();
            ClearData();
            AppendData(' ');
        }

        public override void OnDisable()
        {
            base.OnDisable();
        }

        void Update()
        {
            if (Globals.GlobalVar.dialLeft == 'L')
            {
                SendOSCMessage(Globals.GlobalVar.dialLeft);
                Debug.Log("OscSendDialInput::Send Rotation Left");

                Globals.GlobalVar.dialLeft = ' ';

            } else if (Globals.GlobalVar.dialRight == 'R')
            {
                SendOSCMessage(Globals.GlobalVar.dialRight);
                Debug.Log("OscSendDialInput::Send Rotation Right");

                Globals.GlobalVar.dialRight = ' ';
            }
        }

        public void SendOSCMessage(char fmsg)
        {
            if (_OSCeArg.Packet is OscMessage)
            {
                ((OscMessage)_OSCeArg.Packet).UpdateDataAt(0, fmsg);
            }
            else if (_OSCeArg.Packet is OscBundle)
            {
                foreach (OscMessage m in ((OscBundle)_OSCeArg.Packet).Messages)
                {
                    m.UpdateDataAt(0, fmsg);
                }
            }

            _SendOSCMessage(_OSCeArg);
        }
    }
}