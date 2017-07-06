using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour
{
    public Rigidbody2D Body;
    public List<Vector3> Path;
    public Sprite SpriteA;
    public Sprite SpriteB;
    public ProgressBar StrikeBar;
    public ProgressBar GoldBar;
    public float Speed;
    public int TotalLife;
    public GameObject Tower { get; set; }
    public GameObject Wave { get; set; }
    public int DamageAssigned;
 
    private WaypointManager _aWaypointManager;
    private int _waitPointIndex;

    private void Start()
    {
        Body = GetComponent<Rigidbody2D>();
        this._waitPointIndex = 0;
        this._aWaypointManager = GameObject.Find("waypoints").GetComponent<WaypointManager>();
        Path = this._aWaypointManager.GetPath();
        this.StrikeBar = GameObject.Find("Strikes").GetComponent<ProgressBar>();
        this.GoldBar = GameObject.Find("Oro").GetComponent<ProgressBar>();
    }


    private void Update()
    {
        if (this._waitPointIndex <= Path.Count)
        {
            var point = Path[this._waitPointIndex];
            MoveTo(point);
        }
    }

    private void MoveTo(Vector3 endingPosition)
    {
        var distanceNormalized = (endingPosition - transform.position).normalized;
        Body.velocity = distanceNormalized * Speed * Time.deltaTime;
        //Esto le agrega rotation, para el lado que quiero que vaya a doblar y lo va a haciendo progresivo
        this.transform.right = Vector3.Lerp(this.transform.right, distanceNormalized, 0.5f);
        //Si ya llego, paso al siguiente waitpoint.
        if (this.IsEnemyNearOf(endingPosition))
        {
            //Igualo, para que no haga esa rotacion goma.
            this.transform.position = endingPosition;
            this._waitPointIndex += 1;
            this.SetSpriteFor(this._waitPointIndex);
        }
    }

    private void SetSpriteFor(int waitPointIndex)
    {
        var spriteRender = this.gameObject.GetComponent<SpriteRenderer>();
        switch (waitPointIndex)
        {
            case 0: //derecha
                spriteRender.sprite = SpriteA;
                spriteRender.flipY = false;                
                break;
            case 1: //Arriba
                spriteRender.sprite = SpriteB;
                break;
            case 2: //derecha
                spriteRender.sprite = SpriteA;
                spriteRender.flipY = false;                
                break;
            case 3: // abajo
                spriteRender.sprite = SpriteA;
                spriteRender.flipY = true;
                break;
            case 4: //derecha
                spriteRender.sprite = SpriteA;
                spriteRender.flipY = false;
                break;
        }
    }

    private bool IsEnemyNearOf(Vector3 endingPosition)
    {
        //Si el enemigo esta cerca del x,y, los x,y coinciden los endingPosition.
        var distance = endingPosition - transform.position;
        return Math.Abs(distance.x) <= 0.1f &&
               Math.Abs(distance.y) <= 0.1f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("shoot"))
        {
            this.KillEnemy();
        }

        if (collision.gameObject.CompareTag("scape"))
        {
            this.EnemyScape();
        }
    }

    private void EnemyScape()
    {
        for (int i = 0; i < this.DamageAssigned; i++)
        {
            this.StrikeBar.AddItem();
        }
        
        if (this.StrikeBar.IsFull())
        {
            SceneManager.LoadScene("GameOver");
        }
        Die();
    }

    private void KillEnemy()
    {
        TotalLife -= 1;
        if (TotalLife == 0)
        {
            this.GoldBar.AddItem();
            Die();
        }
    }

    private void Die()
    {
        if (Tower != null)
        {
            this.Tower.GetComponent<Tower>().RemoveFromCollection(this.gameObject);
        }
        this.Wave.GetComponent<Wave>().RemoveFromCollection(this.gameObject);
        Destroy(gameObject);
    }
}
