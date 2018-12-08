using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(transform.parent.name + " " + collision.gameObject.name);
    }
}