using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Shoot : MonoBehaviour
{
    public Rigidbody2D Body;
    public Transform TargetTransform { get; set; }

    private float Speed;
    private int RateOfFire;

    // Use this for initialization
    void Start()
    {
        Speed = 150f;
        Body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveTo(TargetTransform.position);
    }
    
    private void MoveTo(Vector3 endingPosition)
    {
        var currentSpeed = Speed * Time.deltaTime;
        Body.velocity = (endingPosition - transform.position).normalized * currentSpeed;  
    }

    void OnCollisionEnter2D(Collision2D colission)
    {
        Die();
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
