using UnityEngine;
using UnityEngine.SceneManagement;

//La condicion de victoria deberia ser.
// - No quedan mas enemigos en pantalla.
// - No quedan mas waves pendientes.
// - Los strikes no llegaron al maximo.
public class EnemySpawner : MonoBehaviour
{
    public int RateOfSpawn;
    public GameObject WaveGameObject;
    
    private float _coldownSpawn;
    private Wave _wave; 
    
    private void Start()
    {
        _coldownSpawn = this.RateOfSpawn;
        this._wave = this.WaveGameObject.GetComponent<Wave>();
    }

    private void Update()
    {
        this._coldownSpawn -= Time.deltaTime;
        if (this._coldownSpawn <= 0)
        {
            this._wave.CreateEnemy();
            _coldownSpawn = this.RateOfSpawn; 
        }
       
        if (_wave.IsWaveInactives())
        {
           SceneManager.LoadScene("YouWin");
        }
    }
}
