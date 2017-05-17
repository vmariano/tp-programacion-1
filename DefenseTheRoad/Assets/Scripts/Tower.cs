using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Tower : MonoBehaviour
{
    public GameObject bullet;
    public List<GameObject> EnemysInRange;
    private int aux;
    
    
    // Use this for initialization
    void Start ()
    {
        aux = 0;    
    }

    // Update is called once per frame
    void Update () {
        if (aux == 100)
        {
            //this.FireToEnemy(new GameObject());
            aux = 0;
        }
        aux++;
    }

    public void FireToEnemy(GameObject enemy)
    {

        var rotation = Quaternion.identity;
        GameObject.Instantiate(bullet, this.transform.position, rotation);
    }

   void OnTriggerEnter(Collider collider)
    {

        //Si la collision tiene un enemy, me interesa, sino, ignoro.
        var enemy = collider.gameObject;
        Debug.Log(enemy);
        //if (enemy.GetType() == typeof(Enemy))
        //{
        //    EnemysInRange.Add(enemy);
        //}

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("On colission enter  ");
    }
}
