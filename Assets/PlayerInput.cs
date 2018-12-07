using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using HTC.UnityPlugin.Vive;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform camera;

    [SerializeField] private HandRole leftHandRole;
    [SerializeField] private HandRole rightHandRole;
    private ControllerButton triggerButton = ControllerButton.Trigger;

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

    [SerializeField] private Transform feetPos;

    [SerializeField] private float threshold = 2f;
    [SerializeField] private float leftMomentum;
    [SerializeField] private float rightMomentum;

    private bool runTrigger;
    private bool leftPunchTrigger;
    private bool rightPunchTrigger;

    private bool leftJumpTrigger;
    private bool rightJumpTrigger;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float moveTime = 1.5f;

    private Collider punchCollider;

    private Rigidbody rb;
    [SerializeField] private float jumpPower;
    [SerializeField] private bool isGrounded = true;

    // Use this for initialization
    private void Start()
    {
        lastLeftPos = VivePose.GetPose(leftHandRole).pos;
        lastRightPos = VivePose.GetPose(rightHandRole).pos;
        rb = GetComponent<Rigidbody>();
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

        CheckPunch();
        CheckJump();
        CheckRun();

        lastLeftPos = curLeftPos;
        lastRightPos = curRightPos;
    }

    private void CheckRun()
    {
        if ((!ViveInput.GetPress(leftHandRole, triggerButton) && leftMomentum > threshold) ||
            (!ViveInput.GetPress(rightHandRole, triggerButton) && rightMomentum > threshold))
        {
            StartCoroutine("MoveForwardCoroutine");
        }
    }

    private void CheckJump()
    {
        if (ViveInput.GetPress(leftHandRole, triggerButton) && leftMomentum > threshold && Vector3.Angle(leftPunchDirection, Vector3.up) < 45)
        {
            rb.AddForce(Vector3.up * jumpPower);
        }

        if (ViveInput.GetPress(rightHandRole, triggerButton) && rightMomentum > threshold && Vector3.Angle(rightPunchDirection, Vector3.up) < 45)
        {
            rb.AddForce(Vector3.up * jumpPower);
        }
    }

    private void CheckPunch()
    {
        if (ViveInput.GetPress(leftHandRole, triggerButton) && leftMomentum > threshold)
        {
            StartCoroutine("LeftPunchCoroutine");
        }

        if (ViveInput.GetPress(rightHandRole, triggerButton) && rightMomentum > threshold)
        {
            StartCoroutine("RightPunchCoroutine");
        }
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

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.layer == 1 << LayerMask.NameToLayer("Ground"))
        {
            isGrounded = true;
        }
    }
}