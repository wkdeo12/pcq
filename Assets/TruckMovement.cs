using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckMovement : MonoBehaviour
{
    private Rigidbody rb;
    public float moveSpeed = 40f;
    private Vector3 dir;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        dir = new Vector3(0, 0, 1);
    }

    // Update is called once per frame
    private void Update()
    {
        //transform.position = transform.forward * Time.deltaTime * moveSpeed;
        transform.Translate(dir * Time.deltaTime * moveSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        var rr = other.transform.GetChild(1);
    }
}