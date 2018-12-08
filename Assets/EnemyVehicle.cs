using HTC.UnityPlugin.ColliderEvent;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVehicle : MonoBehaviour//, IColliderEventHoverEnterHandler
{
    public float moveSpeed;
    public bool isMoving = true;
    public int hp;

    public ParticleSystem particleSystem;

    //public void OnColliderEventHoverEnter(ColliderHoverEventData eventData)
    //{
    //    Debug.Log(gameObject.name);
    //    isMoving = false;
    //    gameObject.AddComponent(typeof(Rigidbody));
    //    var rb = gameObject.GetComponent<Rigidbody>();
    //    rb.AddExplosionForce(300f, transform.position, 100f, 200f);
    //}

    //private Rigidbody rb;

    // Use this for initialization
    private void Start()
    {
        //rb = GetComponent<Rigidbody>();
        //rb.velocity = transform.forward * moveSpeed;
    }

    // Update is called once per frame
    private void Update()
    {
        if (isMoving) { transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime); }
    }

    public void AfterGrabbed()
    {
        isMoving = false;
        this.transform.tag = "Bomb";
    }

    private void OnCollisionEnter(Collision other)
    //private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("collision with enemy");
            var particle = ParticlePool.instance.GetParticle();
            particle.transform.position = other.transform.position;
            particle.GetComponent<ParticleSystem>().Play();
            Audiomanager.audiosingle.PlayAudio(1);
            GetComponent<Rigidbody>().AddExplosionForce(100, transform.position, 100, 50);
            other.gameObject.GetComponent<Rigidbody>().AddExplosionForce(100, transform.position, 100, 50);
        }
    }
}