using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

namespace RosSharp.RosBridgeClient
{
    public class VIVEToTwist : UnityPublisher<MessageTypes.Geometry.Twist>
    {
        // public VIVETouchPadReader VIVETouchPadLeftReader;
        // public VIVETouchPadReader VIVETouchPadRightReader;
        // public VIVETouchPadReader VIVETouchPadReader;
        public SteamVR_Input_Sources handType;
        public SteamVR_Action_Boolean snapforward;
        public SteamVR_Action_Boolean snapback;
        public SteamVR_Action_Boolean snapleft;
        public SteamVR_Action_Boolean snapright;
        private Vector2 direction;
        private MessageTypes.Geometry.Twist message;
        public double linerspeed = 0.7;
        public double angularconvert = -0.628;
        protected override void Start()
        {
            base.Start();
            InitializeMessage();
        }

        private void Update()
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
                direction = new Vector2 (0,1);
                print("SnapRight");
            }

            if(snapleft.GetState(handType))
            {
                direction = new Vector2 (0,-1);
                print("SnapLeft");
            }
            print("direction" + direction);
            UpdateMessage();
            direction =new Vector2(0,0);
        }

        private void InitializeMessage()
        {
            message = new MessageTypes.Geometry.Twist();
            message.linear = new MessageTypes.Geometry.Vector3();
            message.angular = new MessageTypes.Geometry.Vector3();
        }

        private void UpdateMessage()
        {
            message.linear.x = linerspeed * direction.x;
            message.linear.y = 0;
            message.linear.z = 0;
            message.angular.z = angularconvert * direction.y;
            message.angular.x = 0;
            message.angular.y = 0;
            Publish(message);
        }
    }
}
