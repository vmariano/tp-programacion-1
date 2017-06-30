using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour
{
    public Rigidbody2D Body;
    public List<Vector3> Path;
    public float Speed;
    protected int TotalLife;
    private WaypointManager aWaypointManager;
    private int currentPosition = 0;

    void Start ()
    {
        Body = GetComponent<Rigidbody2D>();
        this.currentPosition = 0;
        this.aWaypointManager = GameObject.Find("waypoints").GetComponent<WaypointManager>();
        Path = this.aWaypointManager.GetPath();
        TotalLife = 2;
        
    }

    // Update is called once per frame
    void Update ()
	{
	    var point = Path[this.currentPosition];
	    MoveTo(point);
    }

    private void MoveTo(Vector3 endingPosition)
    {
        Body.velocity = (endingPosition - transform.position).normalized * Speed * Time.deltaTime;
        // El enemigo ya llego.
        if (this.IsEnemyNearOf(endingPosition)) {
            this.currentPosition += 1;
        }
    }

    private bool IsEnemyNearOf(Vector3 endingPosition)
    {
        //Si el enemigo esta cerca del x,y, los x,y coinciden los endingPosition.
        return Math.Abs(transform.position.x - endingPosition.x) < 0.1f &&
               Math.Abs(transform.position.y - endingPosition.y) < 0.1f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("shoot")) 
        {
            Debug.Log("Me mataron :(");
            TotalLife -= 1;
            if (TotalLife == 0)
            {
                Die();
            }
        } 
        else
        {
            //TODO: implementar restado de vidas Al jugador.
            Debug.Log("Me escape!!");
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
