using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Tower : MonoBehaviour
{
    public GameObject Bullet;
    public List<GameObject> EnemysInRange;
    private int aux;

    // Cada 75 fps lanza un bullet
    private int rateOfFire = 50;

    // Use this for initialization
    void Start ()
    {
        aux = 0;    
    }

    // Update is called once per frame
    void Update () {
        if (aux == rateOfFire)
        {
            if (EnemysInRange.Count() > 0)
            {
                this.FireToEnemy(EnemysInRange.First());
            }
            aux = 0;
        }
        aux++;
    }

    public void FireToEnemy(GameObject enemy)
    {
        var rotation = Quaternion.identity;
        GameObject bullet = GameObject.Instantiate(Bullet, this.transform.position, rotation);
        Shoot shoot = (Shoot)bullet.gameObject.GetComponent(typeof(Shoot));
        shoot.TargetTransform = enemy.transform;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        var enemy = collider.gameObject;
        if (enemy.tag == "enemy")
        {
            EnemysInRange.Add(enemy);
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {        
        EnemysInRange.Remove(collider.gameObject);
    }
}
