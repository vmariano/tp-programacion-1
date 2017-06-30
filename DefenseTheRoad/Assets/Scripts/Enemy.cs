using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour
{
    public Rigidbody2D Body;
    public List<Vector3> Path;
    public float Speed;
    protected int TotalLife;
    private WaypointManager _aWaypointManager;
    private int _currentPosition;
    public ProgressBar StrikeBar;
    public ProgressBar GoldBar;

    void Start()
    {
        Body = GetComponent<Rigidbody2D>();
        this._currentPosition = 0;
        this._aWaypointManager = GameObject.Find("waypoints").GetComponent<WaypointManager>();
        Path = this._aWaypointManager.GetPath();
        TotalLife = 2;
        this.StrikeBar = GameObject.Find("Strikes").GetComponent<ProgressBar>();
        this.GoldBar = GameObject.Find("Oro").GetComponent<ProgressBar>();
    }

    // Update is called once per frame
    void Update ()
	{
	    if (this._currentPosition <= Path.Count)
	    {
	        var point = Path[this._currentPosition];
	        MoveTo(point);
	    }
    }

    private void MoveTo(Vector3 endingPosition)
    {
        var distance = (endingPosition - transform.position);
        Body.velocity = distance.normalized * Speed * Time.deltaTime;
        //Esto le agrega rotation, para el lado que quiero que vaya a doblar y lo va a haciendo progresivo
        //this.transform.right = Vector3.Lerp(this.transform.right, distance.normalized, 0.3f);
        // El enemigo ya llego.
        if (this.IsEnemyNearOf(endingPosition)) {
            this._currentPosition += 1;
        }
    }

    private bool IsEnemyNearOf(Vector3 endingPosition)
    {
        //Si el enemigo esta cerca del x,y, los x,y coinciden los endingPosition.
        return Math.Abs(transform.position.x - endingPosition.x) < 0.3f &&
               Math.Abs(transform.position.y - endingPosition.y) < 0.3f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("shoot"))
        {
            this.KillEnemy();
        } 
        else
        {
            this.EnemyScape();
        }
    }

    private void EnemyScape()
    {
        this.StrikeBar.AddItem();
        if (this.StrikeBar.IsFull())
        {
            SceneManager.LoadScene("GameOver");
        }
        Die();
    }

    private void KillEnemy()
    {
        this.GoldBar.AddItem();
        TotalLife -= 1;
        if (TotalLife == 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
