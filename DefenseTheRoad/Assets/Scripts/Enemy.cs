using System;
using System.Collections.Generic;
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

    public AudioClip DeadFx;
    public AudioClip ScapeFx;
    public AudioSource SoundSource;
 
    private WaypointManager _aWaypointManager;
    private int _waitPointIndex;
    private SpriteRenderer _spriteRender;

    private void Start()
    {
        Body = GetComponent<Rigidbody2D>();
        this._waitPointIndex = 0;
        this._aWaypointManager = GameObject.Find("waypoints").GetComponent<WaypointManager>();
        Path = this._aWaypointManager.GetPath();
        this.StrikeBar = GameObject.Find("Strikes").GetComponent<ProgressBar>();
        this.GoldBar = GameObject.Find("Oro").GetComponent<ProgressBar>();
        this.SoundSource = this.GetComponent<AudioSource>();
        this._spriteRender = this.gameObject.GetComponent<SpriteRenderer>();
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
        //Por favor, perdonenme. 
        if (SceneManager.GetActiveScene().name.Equals("Level1"))
        {
            switch (waitPointIndex)
            {
                case 0: //derecha
                    this.Rigth();         
                    break;
                case 1: //Arriba
                    this.Up();
                    break;
                case 2: //derecha
                    this.Rigth();                
                    break;
                case 3: // abajo
                    this.Down();
                    break;
                case 4: //derecha
                    this.Rigth();
                    break;
            }
        } else if (SceneManager.GetActiveScene().name.Equals("Level2"))
        {
            switch (waitPointIndex)
            {
                case 0: //derecha
                    this.Rigth();         
                    break;
                case 1: //Arriba
                    this.Up();
                    break;
                case 2: //derecha
                    this.Rigth();                
                    break;
                case 3: // abajo
                    this.Down();
                    break;
                case 4: //derecha
                    this.Rigth();
                    break;                
                case 5: //derecha
                    this.Up();
                    break;
            }
        } else if (SceneManager.GetActiveScene().name.Equals("Level3"))
        {
            switch (waitPointIndex)
            {
                case 0: //derecha
                    this.Rigth();         
                    break;
                case 1: //Arriba
                    this.Up();
                    break;
                case 2: //derecha
                    this.Rigth();                
                    break;
                case 3: // abajo
                    this.Down();
                    break;
                case 4: //derecha
                    this.Rigth();
                    break;  
                case 5: //derecha
                    this.Up();
                break;  
                case 6: //derecha
                    this.Rigth();
                break;
            }
        }
  
    }

    private void Down()
    {
        this._spriteRender.sprite = SpriteA;
        this._spriteRender.flipY = true;
    }

    private void Up()
    {
        this._spriteRender.sprite = SpriteB;
    }

    private void Rigth()
    {
        _spriteRender.sprite = SpriteA;
        _spriteRender.flipY = false;       
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
        this.PlayScape();
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
            this.PlayDeath();
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

        //ESto podria ir en el colider en lugar de en el enemigo.
        if (SoundSource.isPlaying)
        {
            InvokeRepeating("Die",0,0.3f);
            return;
        }
        Destroy(gameObject);
    }

    private void PlayDeath()
    {
        if (SoundSource.isPlaying) return;
        SoundSource.PlayOneShot(DeadFx);
    }
    
    private void PlayScape()
    {
       if (SoundSource.isPlaying) return;
       SoundSource.PlayOneShot(ScapeFx);
    }
}
