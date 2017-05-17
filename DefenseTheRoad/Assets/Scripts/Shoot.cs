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
	    var direction = new Vector3();
	    direction.x += 1f;
	    direction.y -= 1f;
	    Body.velocity = direction * Speed;
    }

    void OnCollisionEnter2D(Collision2D colission)
    {
        //Destroy(this.gameObject);
    }
}
