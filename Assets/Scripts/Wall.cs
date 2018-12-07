using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private Rigidbody rb;
    public ParticleSystem punchparticle;

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
        ParticleSystem particle = ParticlePool.instance.GetParticle();

        particle.transform.position = this.transform.position;
        particle.Play();

        rb.velocity = punchvelocity;
    }
}