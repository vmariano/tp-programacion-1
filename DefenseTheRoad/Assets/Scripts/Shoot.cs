using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Shoot : MonoBehaviour
{
    public Rigidbody2D Body;
    private float Speed;
    
    // Use this for initialization
    void Start ()
    {
        Speed = 1f;
	    Body = this.GetComponent<Rigidbody2D>();
	}
    
    // Update is called once per frame
	void Update () {
        Vector3 endingPosition = new Vector3();
        Body.velocity = Vector3.MoveTowards(Body.position, endingPosition, 100f) * Speed;
    }

    void OnCollisionEnter2D(Collision2D colission)
    {
        Destroy(this.gameObject);
    }
}
