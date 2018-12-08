using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollider : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "WALL")
        {
            collision.gameObject.GetComponent<particleman>().ParticleON();
        }
        Debug.Log(collision.gameObject.name);
    }
}