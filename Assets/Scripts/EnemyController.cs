using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class EnemyController : MonoBehaviour
{
    public Transform target ;
    public float velocity;
    public float damage;
    Rigidbody rgb;
    public Action<EnemyController> Esconder;
    private void Start()
    {
        rgb = GetComponent<Rigidbody>();
        MovementToPlayer();
    }
    public void MovementToPlayer()
    {
        if (target != null)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            rgb.velocity = direction * velocity;
        }        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Esconder?.Invoke(this);
        }
    }
}
