using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class MyLineTestUI : MonoBehaviour
{
    public SteamVR_Input_Sources handType;
    public SteamVR_Action_Boolean interactUI;
    public SteamVR_Behaviour_Pose controllerPose;
    public GameObject laserPrefab;
    private GameObject laser;
    private Transform laserTransform;
    private Vector3 hitPoint;

    void Start () {
        laser = Instantiate(laserPrefab);
        laserTransform = laser.transform;
    }

	void Update () {
        // 1
        if (interactUI.GetState(handType))
        {
            RaycastHit hit;
            if (Physics.Raycast(controllerPose.transform.position, transform.forward, out hit, 100))
            {
                hitPoint = hit.point;
                ShowLaser(hit);
                if(hit.collider.name == "ExitButton")
                {
                    print("退出场景");
                    Application.Quit();
                }
            }
        }
        else
        {
            laser.SetActive(false);
        }
    }
    private void ShowLaser(RaycastHit hit)
    {
        laser.SetActive(true);
        laserTransform.position = Vector3.Lerp(controllerPose.transform.position, hitPoint, .5f);
        laserTransform.LookAt(hitPoint);
        laserTransform.localScale = new Vector3(laserTransform.localScale.x, laserTransform.localScale.y, hit.distance);
    }
}
