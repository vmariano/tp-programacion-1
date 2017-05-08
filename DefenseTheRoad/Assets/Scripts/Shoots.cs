using UnityEngine;
using System.Collections;

public class Shoots : MonoBehaviour {

    public Rigidbody2D Body;


    // Use this for initialization
	void Start ()
	{
	    Body = GetComponent<Rigidbody2D>();
	}


    // Update is called once per frame
	void Update () {

    }

    public void GoToEnemy(Enemy e)
    {
        var direction = e.GetPosition();
        direction.x -= 1f;
        direction.y -= 1f;
        Body.velocity = direction * 1;

    }
}
