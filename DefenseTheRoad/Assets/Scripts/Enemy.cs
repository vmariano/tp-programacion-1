using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour
{
    public Rigidbody2D Body;
    public GameObject Point;
    public float Speed;

    void Start ()
    {
        Body = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update ()
	{
        // Body.transform.Rotate(0,0,10f);
        this.MoveTo(Point.transform.position);
    }

    private void MoveTo(Vector3 endingPosition)
    {
        Body.velocity = Vector3.MoveTowards(Body.position, endingPosition, 1000f) * Speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }
}
