using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class BulletController : MonoBehaviour
{
    public float velocity=25;
    public float damage;
    public Transform target;
    Rigidbody rgb;
    public Action<BulletController> Esconder;
    void Start()
    {
        rgb = GetComponent<Rigidbody>();
        MovementToPlayer();
    }
   
    public void MovementToPlayer()
    {        
        rgb.velocity = Vector3.forward * velocity;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            other.gameObject.SetActive(false);
            Esconder?.Invoke(this);
        }
    }
}
