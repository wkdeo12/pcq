using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField]
    public Vector3 kkb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Flyaway(kkb);
    }

    private void Update()
    {
    }

    public void Flyaway(Vector3 punchvelocity)
    {
        //ParticleSystem particle = ParticlePool.instance.GetParticle();
        //particle.transform.position = this.transform.position;
        //particle.Play();

        //rb.velocity = punchvelocity;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "RightHand" || other.transform.tag == "LeftHand")
        {
            //Vector3 velocity = other.transform.parent.GetComponent<VelocityTest>().leftPunchDirection;
            //Flyaway(velocity);
            //ParticleSystem particle = ParticlePool.instance.GetParticle();
            //particle.transform.position = other.transform.position;
            //particle.Play();
            //Destroy(this.gameObject);
        }
    }
}