using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class Tower : MonoBehaviour
{
    public GameObject Bullet;
    public List<GameObject> EnemysInRange;
    private float _resetFire  = 2.5f;
    private float _coldownFire;
    public AudioClip SoundsFx;
    public AudioSource SoundSource;

    private void Start()
    {
        this.SoundSource = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update ()
    {
        _coldownFire -= Time.deltaTime;
        if (EnemysInRange.Any())
        {
            if (_coldownFire <= 0f)
            {
                FireToEnemy(EnemysInRange.Last());
                _coldownFire = _resetFire;
            }
        }        
    }

    private void CleanEnemies()
    {
        if (this.EnemysInRange.Count > 5)
        {
            this.EnemysInRange.Clear();
        }
    }

    public void FireToEnemy(GameObject enemy)
    {
        var rotation = Quaternion.identity;
        GameObject bullet = Instantiate(Bullet, transform.position, rotation);
        Shoot shoot = bullet.gameObject.GetComponent<Shoot>();
        if (enemy != null)
        {
            shoot.TargetEnemy = enemy.transform;
            SoundSource.PlayOneShot(SoundsFx);
        }
    }


    void OnTriggerEnter2D(Collider2D collider)
    {
        var enemy = collider.gameObject;
        if (enemy.CompareTag("enemy"))
        {
            EnemysInRange.Add(enemy);
            enemy.GetComponent<Enemy>().Tower = this.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {        
        this.RemoveFromCollection(collider.gameObject);
    }

    public void RemoveFromCollection(GameObject go)
    {
        EnemysInRange.Remove(go);
    }
}
