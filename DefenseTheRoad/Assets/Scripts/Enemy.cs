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
    private List<Shoot>BulletList;

    private List<Vector3> CreatePath()
    {
        var aPath = new List<Vector3>();
        aPath.Add(new Vector3(-3.68f, 0.179f));
        aPath.Add(new Vector3(2f, 3.05f));
        aPath.Add(new Vector3(5.9f, 1.19f));
        aPath.Add(new Vector3(0.80f, -1.73f));
        aPath.Add(new Vector3(4.25f, -3.49f));
        aPath.Add(new Vector3(12.59f,1.16f));
        return aPath;
    }
    
    void Start ()
    {
        Body = GetComponent<Rigidbody2D>();
        Path = CreatePath();
    }

    // Update is called once per frame
    void Update ()
	{
	    var point = Path.First();
	    MoveTo(point);
    }

    private void MoveTo(Vector3 endingPosition)
    {
        Body.velocity = (endingPosition - transform.position).normalized * Speed;//* Time.deltaTime;
        if (Math.Abs(transform.position.x - endingPosition.x) < 0.5f && Math.Abs(transform.position.y - endingPosition.y) < 0.5f)
        {
            Path.Remove(endingPosition);
            Body.transform.Rotate(0, 0, 100f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("shoot")) 
        {
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
