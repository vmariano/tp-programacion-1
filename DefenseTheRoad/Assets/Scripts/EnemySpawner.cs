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
        var theNewEnemy = Instantiate(enemy, transform.position, Quaternion.identity);
        theNewEnemy.transform.Rotate(0,0,-120f);
    }
}
