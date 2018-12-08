using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckMovement : MonoBehaviour
{
    private Rigidbody rb;
    public float moveSpeed = 10f;
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
        if(other.transform.tag == "RightHand" || other.transform.tag == "LeftHand")
        {
            moveSpeed = 0;
            StartCoroutine(Die(90));
        }
    }

    private IEnumerator Die(int a)
    {
        while(a > 0)
        {
            transform.Translate(-50 * Time.deltaTime, 90 * Time.deltaTime, 10 * Time.deltaTime);
            transform.Rotate(10, -5, 0);
            yield return null;
            a--;
        }
        Destroy(this.gameObject);
        yield return new WaitForSeconds(1f);
    }
}