using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollWall : MonoBehaviour
{
    public float rollspeed = 40;

    private void Start()
    {
    }

    private void Update()
    {
        transform.Rotate(0, rollspeed * Time.deltaTime, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "RightHand" || collision.transform.tag == "LeftHand")
        {
            //ParticleSystem particle = ParticlePool.instance.GetParticle();
            //particle.transform.position = this.transform.position;
            //particle.Play();
            //Destroy(this.gameObject);
        }
    }
}