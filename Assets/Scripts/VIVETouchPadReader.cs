using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

namespace RosSharp.RosBridgeClient
{
    public class VIVETouchPadReader : MonoBehaviour
    {
        public SteamVR_Input_Sources handType;
        public SteamVR_Action_Boolean snapforward;
        public SteamVR_Action_Boolean snapback;
        public SteamVR_Action_Boolean snapleft;
        public SteamVR_Action_Boolean snapright;
        private Vector2 direction;

        public Vector2 Read()
        {
            if(snapforward.GetState(handType))
            {
                direction = new Vector2 (1,0);
                print("SnapForward");
            }

            if(snapback.GetState(handType))
            {
                direction = new Vector2 (-1,0);
                print("SnapBack");
            }

            if(snapright.GetState(handType))
            {
                direction = new Vector2 (1,1);
                print("SnapRight");
            }

            if(snapleft.GetState(handType))
            {
                direction = new Vector2 (-1,-1);
                print("SnapLeft");
            }
            return direction;
        }
    }
}

