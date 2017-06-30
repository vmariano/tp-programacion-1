﻿using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Shoot : MonoBehaviour
{
    public Rigidbody2D Body;
    public Transform TargetTransform { get; set; }

    public float Speed;
    private int RateOfFire;

    // Use this for initialization
    void Start()
    {
        Body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (TargetTransform != null)
        {
            MoveTo(TargetTransform.position);
        }
        else
        {
            //Si perdi la referencia DEBO MORIR!
            this.Die();
        }
    }
    
    private void MoveTo(Vector3 endingPosition)
    {
        var currentSpeed = Speed * Time.deltaTime;
        Body.velocity = (endingPosition - transform.position).normalized * currentSpeed;  
    }

    void OnCollisionEnter2D(Collision2D colission)
    {
        if (colission.gameObject.CompareTag("enemy"))
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
