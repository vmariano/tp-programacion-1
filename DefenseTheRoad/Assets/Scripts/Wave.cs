using System;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{

	public GameObject Enemy;
	public int EnemyCount;
	public Waves ActiveWave;
	public List<GameObject> Enemies;
	public enum Waves
	{
		Inactive = 0,
		First = 1,
		Second = 2,
		Thirt = 3,
		Boss = 4
	}

	public void CreateEnemy()
	{
		switch (this.ActiveWave)
		{
			case Waves.First:
				// 4 enemigos,velocidad 60 vida 2. 
				SetupWave(4, 60, 2, 1 ,Waves.Second);
				break;
			case Waves.Second:
				// 8 enemigos, 80 speed, 4 de vida.
				this.SetupWave(9,80,4, 3 ,Waves.Thirt)
					.GetComponent<SpriteRenderer>().color = Color.magenta;
				break;
			case Waves.Thirt:
					// 6 enemigos, 100 speed, 5 de vida.
					this.SetupWave(6,100,5, 5, Waves.Boss)
						.GetComponent<SpriteRenderer>().color = Color.blue;
				break;
			case Waves.Boss:
				// 1 enemigos, 140 speed, 30 de vida.
				this.SetupWave(1,140, 8, 9, Waves.Inactive)
					.GetComponent<SpriteRenderer>().color = Color.gray;
				break;
		}
		this.EnemyCount += 1;
	}
  
	private GameObject SetupWave(int totalEnemies, int speed, int life, int damage ,Waves nextWave)
	{
		var enemy = Instantiate(Enemy, transform.position, Quaternion.identity);
		this.Enemies.Add(enemy);
		Enemy anEnemy = enemy.gameObject.GetComponent<Enemy>();
		anEnemy.Speed = speed;
		anEnemy.TotalLife = life;
		anEnemy.DamageAssigned = damage;
		anEnemy.Wave = this.gameObject;
		if (this.EnemyCount == totalEnemies)
		{
			this.ActiveWave = nextWave;
			this.EnemyCount = 0;
		}
		return enemy;
	}

	public bool IsWaveInactives()
	{
		return this.ActiveWave.Equals(Waves.Inactive) && Enemies.Count.Equals(0);
	}

	public void RemoveFromCollection(GameObject o)
	{
		this.Enemies.Remove(o);
	}
}
