using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour
{
    protected Rigidbody2D Body;
    public float Speed;
	// Use this for initialization
	void Start ()
	{
        Body = this.GetComponent<Rigidbody2D>();
	    this.Speed = 1;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    this.Move();
       // Body.transform.Rotate(0,0, 10f);
       // Debug.Log(Body.transform.rotation);
    }

    private void Move()
    {
        var d = new Vector2();
        d.x -= 1f;
        d.y -= 1f;
        Body.velocity = d * Speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Destroy(this.gameObject);
    }

    void OnTriggerEnter(Collider collider)
    {
        //Si la collision tiene un enemy, me interesa, sino, ignoro.
        Debug.Log("on trigger");
    }
}
