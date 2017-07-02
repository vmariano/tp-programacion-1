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
				// 10 enemigos,velocidad 60 vida 2. 
				SetupWave(3, 60, 2, Waves.Second);
				break;
			case Waves.Second:
				// 8 enemigos, 80 speed, 4 de vida.
				this.SetupWave(3,80,4,Waves.Thirt)
					.GetComponent<SpriteRenderer>().color = Color.magenta;
				break;
			case Waves.Thirt:
					this.SetupWave(3,100,5,Waves.Boss)
						.GetComponent<SpriteRenderer>().color = Color.blue;
				break;
			case Waves.Boss:
				this.SetupWave(1,140, 30, Waves.Inactive)
					.GetComponent<SpriteRenderer>().color = Color.gray;
				break;
		}
		this.EnemyCount += 1;
	}
  
	private GameObject SetupWave(int totalEnemies, int speed, int life, Waves nextWave)
	{
		var enemy = Instantiate(Enemy, transform.position, Quaternion.identity);
		this.Enemies.Add(enemy);
		Enemy anEnemy = enemy.gameObject.GetComponent<Enemy>();
		anEnemy.Speed = speed;
		anEnemy.TotalLife = life;
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
