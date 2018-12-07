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
    private float magunite;
    void Start () {
        handui = transform.GetComponentInChildren<Image>();
        first = VivePose.GetPose(rightHandRole).pos;
    }
	
	// Update is called once per frame
	void Update () {
        last = VivePose.GetPose(rightHandRole).pos;
        Debug.Log(last);
        uiHandRot = VivePose.GetPose(rightHandRole).rot;
       // Debug.Log(uiHandRot);

        transform.LookAt(Camera.main.transform);
        magunite = (last - first).magnitude;
       // Debug.Log(magunite);

        if (uiHandRot.y >= 0.35 && last.y >=1.6f)
            handui.gameObject.SetActive(true);
        else if (uiHandRot.y <= 0.2 && last.y <  1.5f)
            handui.gameObject.SetActive(false);


    }
}
