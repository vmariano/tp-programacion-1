using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Shoot : MonoBehaviour
{
    public Rigidbody2D Body;
    private float Speed;
        
    public Transform TargetTransform { get; set; }

    // Use this for initialization
    void Start ()
    {
        Speed = 1f;
	    Body = this.GetComponent<Rigidbody2D>();
    }
    
    // Update is called once per frame
	void Update () 
    {
        this.MoveTo(this.TargetTransform);
    }

    private void MoveTo(Transform endingPosition)
    {
        Body.transform.position = Vector3.MoveTowards(Body.position, endingPosition.position, 1000f) * Speed;
    }

    void OnCollisionEnter2D(Collision2D colission)
    {
        Destroy(this.gameObject);
    }
}
