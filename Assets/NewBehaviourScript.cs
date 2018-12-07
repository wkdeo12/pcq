using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HTC.UnityPlugin.Vive;

public class NewBehaviourScript : MonoBehaviour {

    public HandRole handRole;
    public ControllerButton controllerButton;
    public Rigidbody rid;

    public Vector3 firstPos;
    public Vector3 velocity;
    public Vector3 pos;
    public Quaternion rot;


    public Transform righthand;

    // Use this for initialization
    void Start () {
        firstPos = VivePose.GetPose(handRole).pos;

    }
	
	// Update is called once per frame
	void Update () {

        pos = VivePose.GetPose(handRole).pos;
       // Debug.Log("pos = " + pos);
        rot = VivePose.GetPose(handRole).rot;
       // Debug.Log("rot = " + rot);
        velocity = (firstPos - pos);




         Debug.Log("velocity = "+ velocity.magnitude);
        // firstPos = VivePose.GetPose(handRole).pos;
      //  Debug.Log("RIghthand = " + righthand.position);

    }
}
