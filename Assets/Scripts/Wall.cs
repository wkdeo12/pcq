using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private Rigidbody rb;
    public ParticleSystem punchparticle;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Flyaway(new Vector3(0, 1, 0));
    }

    private void Update()
    {
    }

    private void Flyaway(Vector3 punchvelocity)
    {
        ParticleSystem particle = ParticlePool.instance.GetParticle();

        particle.transform.position = this.transform.position;
        particle.Play();

        rb.velocity = punchvelocity;
    }
}