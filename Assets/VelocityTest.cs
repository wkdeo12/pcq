using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using HTC.UnityPlugin.Vive;

public class VelocityTest : MonoBehaviour
{
    public Transform player;
    public Transform camera;

    public HandRole handRole;
    public ControllerButton controllerButton = ControllerButton.Trigger;
    public Rigidbody rid;

    public Vector3 lastPos;
    public Vector3 punchDirection;
    public Vector3 pos;
    public Quaternion rot;

    public Transform righthand;

    public float threshold = 2.25f;
    public float momentum;
    public bool runTrigger;
    public bool punchTrigger;
    public float moveSpeed;

    public float moveTime = 1.5f;

    public Vector3 moveVector;

    private Collider punchCollider;

    // Use this for initialization
    private void Start()
    {
        lastPos = VivePose.GetPose(handRole).pos;
    }

    // Update is called once per frame
    private void Update()
    {
        pos = VivePose.GetPose(handRole).pos;

        punchDirection = (pos - lastPos);
        momentum = punchDirection.magnitude / Time.deltaTime;
        //Debug.Log("velocity = " + momentum);

        if (ViveInput.GetPress(handRole, controllerButton) && momentum > threshold)
        {
            punchTrigger = true;
        }
        else
        {
            punchTrigger = false;
        }

        if (!ViveInput.GetPress(handRole, controllerButton) && momentum > threshold)
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
            //player.Translate(camera.transform.forward * Time.deltaTime * moveSpeed);
            //player.Translate(moveVector);
        }

        if (punchTrigger)
        {
            StartCoroutine("MoveForwardCoroutine");
            StartCoroutine("PunchCoroutine");
        }

        lastPos = pos;
    }

    private IEnumerator MoveForwardCoroutine()
    {
        float timer = 0f;
        while (timer < moveTime)
        {
            timer += Time.deltaTime;
            //moveVector = camera.transform.forward * Time.deltaTime * moveSpeed
            player.Translate(camera.transform.forward * Time.deltaTime * moveSpeed);
            yield return null;
        }
    }

    private IEnumerator PunchCoroutine()
    {
        var punches = FindObjectsOfType<AttackCollider>();
        punches[0].gameObject.GetComponent<Collider>().isTrigger = false;
        punches[1].gameObject.GetComponent<Collider>().isTrigger = false;
        yield return new WaitForSeconds(0.25f);
        punches[0].gameObject.GetComponent<Collider>().isTrigger = true;
        punches[1].gameObject.GetComponent<Collider>().isTrigger = true;
    }
}