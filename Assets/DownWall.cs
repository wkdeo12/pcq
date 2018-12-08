using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownWall : MonoBehaviour
{
    public Transform ground;
    public float distance;
    public float stopdis;

    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if(this.transform.position.y - ground.transform.position.y < 3)
        {
            return;
        }

        this.transform.Translate(0, -30 * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "RightHand" || other.transform.tag == "LeftHand")
        {
            //Vector3 velocity = other.transform.parent.GetComponent<VelocityTest>().leftPunchDirection;
            //Flyaway(velocity);
            ParticleSystem particle = ParticlePool.instance.GetParticle();
            particle.transform.position = other.transform.position;
            particle.Play();
            Destroy(this.gameObject);
        }
    }
}