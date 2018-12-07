using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using HTC.UnityPlugin.Vive;
using UnityEngine.UI;
public class BillboardTest : MonoBehaviour {

    [SerializeField]
    private HandRole rightHandRole;

    public Quaternion uiHandRot;

    private  Image handui;

    private Vector3 first;
    private Vector3 last;
    // Use this for initialization


    public Transform righthand;


    void Start () {
        handui = transform.GetComponentInChildren<Image>();
        first = VivePose.GetPose(rightHandRole).pos;
    }
	
	// Update is called once per frame
	void Update () {
        last = VivePose.GetPose(rightHandRole).pos;
        uiHandRot = VivePose.GetPose(rightHandRole).rot;

        //transform.LookAt(Camera.main.transform);

        Vector3 euler = righthand.eulerAngles;
        float eulery = Mathf.Abs(euler.y - 360.0f);
       

        if (eulery >= 35.0f && eulery < 200.0f && last.y >= 1.6f)
            handui.gameObject.SetActive(true);
        else if (last.y <=1.5)
            handui.gameObject.SetActive(false);


    }
}
