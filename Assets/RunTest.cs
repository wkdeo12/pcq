using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunTest : MonoBehaviour {

    [SerializeField] private PlayerMovement movement;

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, transform.localScale);
    }

    private void OnTriggerEnter(Collider other)
    {
        //if (other.tag.Contains("Hand"))
        {
            Debug.Log(other.gameObject.name);
        }

        if (other.gameObject.name == "Camera")
        {
            return;
        }

        movement.Move();
    }
}
