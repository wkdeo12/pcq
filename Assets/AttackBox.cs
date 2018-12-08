using HTC.UnityPlugin.ColliderEvent;
using HTC.UnityPlugin.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBox : MonoBehaviour, IColliderEventHoverEnterHandler
{
    [SerializeField] private float attackPhaseTime;
    [SerializeField] private float attackCoolTime;
    private bool isReady;
    private Collider box;

    // Use this for initialization
    private void Start()
    {
        box = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.AddComponent(typeof(Rigidbody));
            var rb = other.gameObject.GetComponent<Rigidbody>();
            rb.AddExplosionForce(300f, transform.position, 100f, 200f);
        }
    }

    private IEnumerator AttackCoroutine()
    {
        Debug.Log("AttackCoroutine");
        box.isTrigger = false;
        isReady = false;
        yield return new WaitForSeconds(attackPhaseTime);
        box.isTrigger = true;
        yield return new WaitForSeconds(attackCoolTime);
        isReady = true;
    }

    public void OnColliderEventHoverEnter(ColliderHoverEventData eventData)
    {
        StartCoroutine("AttackCoroutine");
    }
}