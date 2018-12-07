using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using HTC.UnityPlugin.Vive;

public class VelocityTest : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform camera;

    [SerializeField] private HandRole leftHandRole;
    [SerializeField] private HandRole rightHandRole;
    [SerializeField] private ControllerButton triggerButton = ControllerButton.Trigger;

    private Vector3 lastLeftPos;
    private Vector3 curLeftPos;
    private Vector3 lastRightPos;
    private Vector3 curRightPos;
    private Vector3 leftPunchDirection;
    private Vector3 rightPunchDirection;

    private Quaternion leftRot;
    private Quaternion rightRot;

    public Transform leftHand;
    public Transform rightHand;

    [SerializeField] private float threshold = 2f;
    [SerializeField] private float leftMomentum;
    [SerializeField] private float rightMomentum;
    [SerializeField] private bool runTrigger;
    [SerializeField] private bool leftPunchTrigger;
    [SerializeField] private bool rightPunchTrigger;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float moveTime = 1.5f;

    private Collider punchCollider;

    // Use this for initialization
    private void Start()
    {
        lastLeftPos = VivePose.GetPose(leftHandRole).pos;
        lastRightPos = VivePose.GetPose(rightHandRole).pos;
    }

    // Update is called once per frame
    private void Update()
    {
        curLeftPos = VivePose.GetPose(leftHandRole).pos;
        curRightPos = VivePose.GetPose(rightHandRole).pos;

        leftPunchDirection = (curLeftPos - lastLeftPos);
        rightPunchDirection = (curRightPos - lastRightPos);

        leftMomentum = leftPunchDirection.magnitude / Time.deltaTime;
        rightMomentum = rightPunchDirection.magnitude / Time.deltaTime;

        //Debug.Log("velocity = " + momentum);

        if (ViveInput.GetPress(leftHandRole, triggerButton) && leftMomentum > threshold)
        {
            leftPunchTrigger = true;
        }
        else
        {
            leftPunchTrigger = false;
        }

        if (ViveInput.GetPress(rightHandRole, triggerButton) && rightMomentum > threshold)
        {
            rightPunchTrigger = true;
        }
        else
        {
            rightPunchTrigger = false;
        }

        if ((!ViveInput.GetPress(leftHandRole, triggerButton) && leftMomentum > threshold) ||
            (!ViveInput.GetPress(rightHandRole, triggerButton) && rightMomentum > threshold))
        {
            runTrigger = true;
        }
        else
        {
            runTrigger = false;
        }

        if (runTrigger)
        {
            StartCoroutine("MoveForwardCoroutine");
            runTrigger = false;
        }

        if (leftPunchTrigger)
        {
            StartCoroutine("LeftPunchCoroutine");
        }

        if (rightPunchTrigger)
        {
            StartCoroutine("RightPunchCoroutine");
        }

        lastLeftPos = curLeftPos;
        lastRightPos = curRightPos;
    }

    private IEnumerator MoveForwardCoroutine()
    {
        float timer = 0f;
        while (timer < moveTime)
        {
            timer += Time.deltaTime;
            Vector3 direction = new Vector3(camera.transform.forward.x, 0, camera.transform.forward.z);
            player.Translate(direction * Time.deltaTime * moveSpeed);
            yield return null;
        }
    }

    private IEnumerator LeftPunchCoroutine()
    {
        Collider punch = leftHand.GetComponentInChildren<AttackCollider>().gameObject.GetComponent<Collider>();
        punch.isTrigger = false;
        yield return new WaitForSeconds(0.5f);
        punch.isTrigger = true;
    }

    private IEnumerator RightPunchCoroutine()
    {
        Collider punch = rightHand.GetComponentInChildren<AttackCollider>().gameObject.GetComponent<Collider>();
        punch.isTrigger = false;
        yield return new WaitForSeconds(0.5f);
        punch.isTrigger = true;
    }
}