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
    
    void Start ()
    {
        Body = GetComponent<Rigidbody2D>();
        Path = PathSaver.PathForLevel_3();
        Speed = 100f;
        TotalLife = 2;
    }

    // Update is called once per frame
    void Update ()
	{
	    var point = Path.First();
	    MoveTo(point);
    }

    private void MoveTo(Vector3 endingPosition)
    {
        Body.velocity = (endingPosition - transform.position).normalized * Speed * Time.deltaTime;
        if (Math.Abs(transform.position.x - endingPosition.x) < 0.5f && Math.Abs(transform.position.y - endingPosition.y) < 0.5f)
        {
            Path.Remove(endingPosition);
        }
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
