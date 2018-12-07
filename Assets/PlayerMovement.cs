using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [SerializeField] Transform viveCamRig;
    [SerializeField] Transform cam;
    [SerializeField] private float speed;
    [SerializeField] private float moveTime;
    [SerializeField] Rigidbody rb;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Move()
    {
        StartCoroutine(MoveForward());
    }

    IEnumerator MoveForward()
    {
        float timer = 0;
        while (timer < moveTime)
        {
            timer += Time.deltaTime;
            rb.velocity = cam.transform.forward * speed;
            yield return null;
        }
        rb.velocity = Vector3.zero;
    }
}
