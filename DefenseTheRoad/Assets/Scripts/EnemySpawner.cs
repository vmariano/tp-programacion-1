using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public int aux;

    // Use this for initialization
    void Start ()
	{
	    aux = 0;
	}

    // Update is called once per frame
	void Update () {
	    
	    if (aux == 170)
	    {
	        this.CreateEnemy();
	        aux = 0;
	    }
	    aux++;
    }

    private void CreateEnemy()
    {
        var rotation = Quaternion.identity;
        rotation.Set(rotation.x, rotation.y, -30f, rotation.w);
        GameObject.Instantiate(this.enemy, this.transform.position, rotation);
    }
}
