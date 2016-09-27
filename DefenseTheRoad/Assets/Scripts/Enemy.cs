using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Rigidbody2D Body;
    public float Speed = 1f;

	// Use this for initialization
	void Start ()
	{
	    Body = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
	{
        Vector3 direction = new Vector3();
        direction.x -= 1f ;
        direction.y -= 1f;
        Body.velocity = direction * Speed;
	    Debug.Log(direction);
        if (Body.position.x < -6 || Body.position.y < -5  )
	    {
	        Destroy(this);
	    }
    }

    Vector3 GetPosition()
    {
        return Body.velocity;
    }
    

}
