using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class MovementController : Stats
{
    [Header("Movimiento")]
    Rigidbody rgbNave;
    [SerializeField] private float velocity;
    public bool estatico = true;
    public Action<MovementController,EnemyController> RecibirDaño;
    public Action<MovementController, EnemyController> ActualizarVidaUI;

    private void Start()
    {        
        rgbNave = GetComponent<Rigidbody>();
        RecibirDaño += UpdateLife;
    }
       
    private void Update()
    {
        if (!estatico)
        {
            Movement();
            if (Input.GetKey(KeyCode.W))
            {
                transform.position = new Vector3(transform.position.x, transform.position.y +(Time.deltaTime*velocity) , transform.position.z);
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - (Time.deltaTime * velocity), transform.position.z);
            }
            float accelerationY = Input.acceleration.y;
            transform.position += Vector3.up * Time.deltaTime * velocity * accelerationY;
        }
        
    }
    public void Movement()
    {
        rgbNave.velocity = velocity * Vector3.forward;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 6)
        {            
            RecibirDaño?.Invoke(this,other.gameObject.GetComponent<EnemyController>());
        }
    }

    public void UpdateLife(MovementController movementController, EnemyController enemyController)
    {
        movementController.life -= enemyController.damage;
        ActualizarVidaUI?.Invoke(movementController, enemyController);
    }
}
