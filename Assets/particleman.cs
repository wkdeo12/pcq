using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleman : MonoBehaviour
{
    public ParticleSystem punchparticle;
    public ParticleSystem punchparticle2;

    // Use this for initialization
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void ParticleON()
    {
        punchparticle.Play();
        punchparticle2.Play();
    }
}