using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour
{
    public Rigidbody2D Body;
    public List<Vector3> Path;
    public float Speed;
    
    void Start ()
    {
        Body = GetComponent<Rigidbody2D>();
        Path = PathSaver.PathForLevel_3();
        Speed = 100f;
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
        if (collision.gameObject.CompareTag("shoot")) 
        {
            //Todo: implementar puntos
            Debug.Log("Me mataron");
        } 
        else
        {
            //TODO: implementar restado de vidas.
            Debug.Log("Me escape!!");
        }
        Destroy(gameObject);
    }
}
