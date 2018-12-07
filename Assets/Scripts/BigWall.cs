using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigWall : MonoBehaviour
{
    // Use this for initialization
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnCollisionEnter(Collision coll)
    {
        if(coll.transform.tag == "WALL")
        {
        }
    }
}