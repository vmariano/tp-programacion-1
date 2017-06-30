using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public int rateOfSpawn;

    // Use this for initialization
    void Start ()
	{
	    InvokeRepeating("CreateEnemy", 0, rateOfSpawn); 
    }

    private void CreateEnemy()
    {
        Instantiate(enemy, transform.position, Quaternion.identity);
    }
}
