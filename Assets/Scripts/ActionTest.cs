using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ActionTest : MonoBehaviour
{
    public SteamVR_Input_Sources handType;
    public SteamVR_Action_Boolean SnapForward;
    public SteamVR_Action_Boolean SnapBack;
    public SteamVR_Action_Boolean SnapTurnRight;
    public SteamVR_Action_Boolean SnapTurnLeft;

    void Update()
    {
        print("SnapForward" + SnapForward.GetState(handType));
        print("SnapBack" + SnapBack.GetState(handType));
        print("SnapRight" + SnapTurnRight.GetState(handType));
        print("SnapLeft" + SnapTurnLeft.GetState(handType));
    }

}
