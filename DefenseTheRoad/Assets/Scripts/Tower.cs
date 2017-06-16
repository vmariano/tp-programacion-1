using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class Tower : MonoBehaviour
{
    public GameObject Bullet;
    public List<GameObject> EnemysInRange;
    private float _rateOfFire  = 4.5f;
    private float _coldownFire = 4.5f;

    // Update is called once per frame
    void Update ()
    {
        if (EnemysInRange.Any())
        {
            _coldownFire -= Time.deltaTime;
            if (_coldownFire <= 0)
            {
                Debug.Log("Disparo!");
                FireToEnemy(EnemysInRange.First());
                _coldownFire = _rateOfFire; 
            }
        }
    }

    public void FireToEnemy(GameObject enemy)
    {
        var rotation = Quaternion.identity;
        GameObject bullet = Instantiate(Bullet, transform.position, rotation);
        Shoot shoot = bullet.gameObject.GetComponent<Shoot>();
        shoot.TargetTransform = enemy.transform;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        var enemy = collider.gameObject;
        if (enemy.CompareTag("enemy"))
        {
            EnemysInRange.Add(enemy);
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {        
        EnemysInRange.Remove(collider.gameObject);
    }
}
