using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public int rateOfSpawn;
    private float _coldownSpawn;
    public int elapsedEnemies;

    private void Start()
    {
        _coldownSpawn = this.rateOfSpawn; 
    }

    private void Update()
    {
        this._coldownSpawn -= Time.deltaTime;
        if (this._coldownSpawn <= 0)
        {
	        this.CreateEnemy(); 
            _coldownSpawn = this.rateOfSpawn; 
        }             
    }

    private void CreateEnemy()
    {
        var enemyGameObject = Instantiate(enemy, transform.position, Quaternion.identity);
        elapsedEnemies += 1;
        if (elapsedEnemies <= 5)
        {
            this.CreateFirstWave(enemyGameObject);
        }
        else if (elapsedEnemies <= 15)
        {
            this.CreateSecondWave(enemyGameObject);
        }
        else if (elapsedEnemies <= 16)
        {
            this.CreateBossWave(enemyGameObject);
        } else if (elapsedEnemies <= 17)
        {
            SceneManager.LoadScene("YouWin");
        }
    }

    // 10 enemigos, vida 1. velocidad 50
    void CreateFirstWave(GameObject enemy)
    {
        Enemy anEnemy = enemy.gameObject.GetComponent<Enemy>();
        anEnemy.Speed = 60;
        anEnemy.TotalLife = 2;
     
    }
        
    // 10 enemigos, vida 3. velocidad 70
    void CreateSecondWave(GameObject enemy)
    {
        Enemy anEnemy = enemy.gameObject.GetComponent<Enemy>();
        enemy.GetComponent<SpriteRenderer>().color = Color.magenta;
        anEnemy.Speed = 80;
        anEnemy.TotalLife = 4;
    }
    
    // 1 enemgio de 15 de vida velocidad 130
    void CreateBossWave(GameObject enemy)
    {
        Enemy anEnemy = enemy.gameObject.GetComponent<Enemy>();
        enemy.GetComponent<SpriteRenderer>().color = Color.gray;
        anEnemy.Speed = 130;
        anEnemy.TotalLife = 20;
    }
    


}
